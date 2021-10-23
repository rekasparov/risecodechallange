using Microsoft.EntityFrameworkCore;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
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
    }
}
