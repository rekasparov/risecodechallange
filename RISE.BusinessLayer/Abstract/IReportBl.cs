using RISE.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.BusinessLayer.Abstract
{
    public interface IReportBl
    {
        Task<Guid> CreateReport();
        Task DeleteReport(Guid uuid);
        Task UpdateStatus(Guid uuid);
        Task<List<ReportDto>> GetReportList(int pageIndex, int pageSize);
    }
}
