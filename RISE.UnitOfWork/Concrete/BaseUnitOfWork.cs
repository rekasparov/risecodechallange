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
        private readonly object locker = new object();

        private DbContext _dbContext;

        private DbContext dbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    lock (_dbContext)
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

        public IContactTypeDal ContactType => new ContactTypeDal(dbContext);

        public IPersonDal Person => new PersonDal(dbContext);

        public IPersonContactDal PersonContact => new PersonContactDal(dbContext);

        public IReportDal Report => new ReportDal(dbContext);

        public async Task<int> SaveChangesAsync()
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
    }
}
