using Microsoft.EntityFrameworkCore;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.Entity;
using RISE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.BusinessLayer.Concrete
{
    public class ReportBl : IReportBl
    {
        private readonly IBaseUnitOfWork unitOfWork;

        public ReportBl(IBaseUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateReport(ReportDto model)
        {
            try
            {
                Report report = new Report()
                {
                    UUID = Guid.NewGuid(),
                    RequestDate = DateTime.Now,
                    Status = false
                };

                foreach (var reportDetail in model.ReportDetails)
                {
                    report.ReportDetails.Add(new ReportDetail
                    {
                        Location = reportDetail.Location
                    });
                }

                unitOfWork.Report.Insert(report);

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }

        public Task<List<ReportDto>> GetReportList(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
