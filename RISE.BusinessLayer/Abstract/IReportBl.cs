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
        Task CreateReportByLocation();
        Task<List<ReportDto>> GetReportList(int pageIndex, int pageSize);
    }
}
