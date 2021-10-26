using Microsoft.EntityFrameworkCore;
using RISE.DataAccessLayer.Abstract;
using RISE.DataAccessLayer.Concrete;
using RISE.Entity;
using RISE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.UnitOfWork.Concrete
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        private static readonly object locker = new object();

        private static DbContext _dbContext;

        private static DbContext dbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    lock (locker)
                    {
                        if (_dbContext == null)
                        {
                            _dbContext = new RISETESTDBContext();
                        }
                    }
                }

                return _dbContext;
            }
        }

        public IPersonDal Person => new PersonDal(dbContext);

        public IPersonContactDal PersonContact => new PersonContactDal(dbContext);

        public IReportDal Report => new ReportDal(dbContext);

        public IReportDetailDal ReportDetail => new ReportDetailDal(dbContext);

        public async Task<int> CommitAsync()
        {
            try
            {
                return await dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task RollBackAsync()
        {
            try
            {
                await dbContext.DisposeAsync();
                await _dbContext.DisposeAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
