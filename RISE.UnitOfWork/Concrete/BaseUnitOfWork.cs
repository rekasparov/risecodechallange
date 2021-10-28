using Microsoft.EntityFrameworkCore;
using RISE.DataAccessLayer.Abstract;
using RISE.DataAccessLayer.Concrete;
using RISE.Entity;
using RISE.Entity.PERSONTESTDB;
using RISE.Entity.REPORTTESTDB;
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
        private static readonly object lockerForPerson = new object();
        private static readonly object lockerForReport = new object();

        private static DbContext _personDbContext;

        private static DbContext personDbContext
        {
            get
            {
                if (_personDbContext == null)
                {
                    lock (lockerForPerson)
                    {
                        if (_personDbContext == null)
                        {
                            _personDbContext = new PERSONTESTDBContext();
                        }
                    }
                }

                return _personDbContext;
            }
        }

        private static DbContext _reportDbContext;

        private static DbContext reportDbContext
        {
            get
            {
                if (_reportDbContext == null)
                {
                    lock (lockerForPerson)
                    {
                        if (_reportDbContext == null)
                        {
                            _reportDbContext = new REPORTTESTDBContext();
                        }
                    }
                }

                return _reportDbContext;
            }
        }

        public IPersonDal Person => new PersonDal(personDbContext);

        public IPersonContactDal PersonContact => new PersonContactDal(personDbContext);

        public IReportDal Report => new ReportDal(reportDbContext);

        public IReportDetailDal ReportDetail => new ReportDetailDal(reportDbContext);

        public async Task<int> PersonCommitAsync()
        {
            try
            {
                return await personDbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> ReportCommitAsync()
        {
            try
            {
                return await reportDbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task PersonRollBackAsync()
        {
            try
            {
                if (personDbContext != null) await personDbContext.DisposeAsync();
                if (_personDbContext != null) await _personDbContext.DisposeAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task ReportRollBackAsync()
        {
            try
            {
                if (reportDbContext != null) await reportDbContext.DisposeAsync();
                if (_reportDbContext != null) await _reportDbContext.DisposeAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
