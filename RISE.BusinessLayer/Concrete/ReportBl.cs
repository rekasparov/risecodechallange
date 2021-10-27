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
    public class ReportBl : IReportBl
    {
        private readonly IBaseUnitOfWork unitOfWork = new BaseUnitOfWork();

        public async Task<Guid> CreateReport()
        {
            try
            {
                Guid uuid = Guid.NewGuid();

                Report report = new Report()
                {
                    UUID = uuid,
                    RequestDate = DateTime.Now,
                    Status = false
                };

                unitOfWork.Report.Insert(report);

                await unitOfWork.CommitAsync();

                return uuid;
            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }

        public async Task<List<ReportDto>> GetReportList(int pageIndex, int pageSize)
        {
            try
            {
                IQueryable<ReportDto> query = unitOfWork.Report.Select()
                    .Select(x => new ReportDto
                    {
                        UUID = x.UUID,
                        RequestDate = x.RequestDate,
                        Status = x.Status
                    })
                    .OrderByDescending(x => x.RequestDate);

                if (pageSize != 0) query = query.Skip(pageIndex * pageSize).Take(pageSize);

                return await query.ToListAsync();
            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }

        public async Task UpdateStatus(Guid uuid)
        {
            try
            {
                Report report = await unitOfWork.Report.Select(x => x.UUID == uuid).FirstOrDefaultAsync();

                if (report != null) report.Status = true;

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
