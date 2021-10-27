using RISE.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.BusinessLayer.Abstract
{
    public interface IReportDetailBl
    {
        Task<List<ReportDetailDto>> GetReportDetailsByReportId(Guid reportId);
        Task CreateReportByReportId(Guid reportId);
    }
}
