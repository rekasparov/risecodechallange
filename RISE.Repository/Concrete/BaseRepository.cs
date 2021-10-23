using Microsoft.EntityFrameworkCore;
using RISE.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RISE.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, new()
    {
        protected DbContext dbContext;

        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(T enitity)
        {
            try
            {
                dbContext.Remove(enitity).State = EntityState.Deleted;
            }
            catch
            {
                throw;
            }
        }

        public void Insert(T enitity)
        {
            try
            {
                dbContext.Add(enitity).State = EntityState.Added;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                if (predicate != null) return dbContext.Set<T>().Where(predicate);

                return dbContext.Set<T>().AsQueryable();
            }
            catch
            {
                throw;
            }
        }

        public void Update(T enitity)
        {
            try
            {
                dbContext.Update(enitity).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }
    }
}
