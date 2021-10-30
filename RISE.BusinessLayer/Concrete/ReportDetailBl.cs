using Microsoft.EntityFrameworkCore;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.Entity.REPORTTESTDB;
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

        public async Task<List<ReportDetailDto>> GetReportDetailsByReportId(Guid reportId)
        {
            try
            {
                return await unitOfWork.ReportDetail.Select(x => x.ReportId == reportId)
                    .Select(x => new ReportDetailDto
                    {
                        UUID = x.UUID,
                        ReportId = x.ReportId,
                        Location = x.Location,
                        PersonCount = x.PersonCount,
                        PhoneNumberCount = x.PhoneNumberCount
                    }).ToListAsync();
            }
            catch
            {
                await unitOfWork.ReportRollBackAsync();

                throw;
            }
        }

        public async Task CreateReport(List<ReportDetailDto> model)
        {
            try
            {
                unitOfWork.ReportDetail.InsertRange(model.Select(x => new ReportDetail()
                {
                    UUID = x.UUID,
                    ReportId = x.ReportId,
                    Location = x.Location,
                    PersonCount = x.PersonCount,
                    PhoneNumberCount = x.PhoneNumberCount
                }).ToList());

                await unitOfWork.ReportCommitAsync();
            }
            catch
            {
                await unitOfWork.ReportRollBackAsync();

                throw;
            }
        }
    }
}
