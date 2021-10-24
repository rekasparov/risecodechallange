using Microsoft.EntityFrameworkCore;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.Entity;
using RISE.UnitOfWork.Abstract;
using RISE.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.BusinessLayer.Concrete
{
    public class ReportDetailBl : IReportDetailBl
    {
        private readonly IBaseUnitOfWork unitOfWork = new BaseUnitOfWork();

        public async Task<ReportDetailDto> GetReportDetailByReportUUID(Guid reportId)
        {
            try
            {
                return await unitOfWork.ReportDetail.Select(x => x.ReportId == reportId)
                    .Include(x => x.Report)
                    .Select(x => new ReportDetailDto
                    {
                        UUID = x.UUID,
                        ReportId = x.ReportId,
                        Location = x.Location,
                        PersonCount = x.PersonCount,
                        PhoneNumberCount = x.PhoneNumberCount,
                        Report = new ReportDto()
                        {
                            UUID = x.Report.UUID,
                            RequestDate = x.Report.RequestDate,
                            Status = x.Report.Status
                        }
                    }).FirstOrDefaultAsync();
            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }

        public async Task CreateReportByReportId(Guid reportId)
        {
            try
            {
                List<string> locationList = await unitOfWork.PersonContact.Select().Select(x => x.Location).Distinct().ToListAsync();

                foreach (var location in locationList)
                {
                    int personCount = await unitOfWork.PersonContact.Select(x => x.Location == location).Select(x => x.PersonId).Distinct().CountAsync();

                    int phoneNumberCount = await unitOfWork.PersonContact.Select(x => x.Location == location).Select(x => x.PhoneNumber).CountAsync();

                    unitOfWork.ReportDetail.Insert(new ReportDetail()
                    {
                        UUID = Guid.NewGuid(),
                        ReportId = reportId,
                        Location = location,
                        PersonCount = personCount,
                        PhoneNumberCount = phoneNumberCount
                    });
                }

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }
    }
}
