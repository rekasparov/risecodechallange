using Microsoft.EntityFrameworkCore;
using RISE.DataAccessLayer.Abstract;
using RISE.Entity.REPORTTESTDB;
using RISE.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.DataAccessLayer.Concrete
{
    public class ReportDetailDal : BaseRepository<ReportDetail>, IReportDetailDal
    {
        public ReportDetailDal(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
