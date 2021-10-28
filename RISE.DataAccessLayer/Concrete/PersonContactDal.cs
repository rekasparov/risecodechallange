using Microsoft.EntityFrameworkCore;
using RISE.DataAccessLayer.Abstract;
using RISE.Entity.PERSONTESTDB;
using RISE.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.DataAccessLayer.Concrete
{
    public class PersonContactDal : BaseRepository<PersonContact>, IPersonContactDal
    {
        public PersonContactDal(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
