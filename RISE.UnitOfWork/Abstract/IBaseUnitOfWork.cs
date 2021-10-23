using RISE.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.UnitOfWork.Abstract
{
    public interface IBaseUnitOfWork
    {
        IPersonDal Person { get; }
        IPersonContactDal PersonContact { get; }
        IReportDal Report { get; }
        IReportDetailDal ReportDetail { get; }

        Task<int> CommitAsync();
        Task RollBackAsync();
    }
}
