﻿using Microsoft.EntityFrameworkCore;
using RISE.DataAccessLayer.Abstract;
using RISE.Entity;
using RISE.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.DataAccessLayer.Concrete
{
    public class ContactTypeDal : BaseRepository<ContactType>, IContactTypeDal
    {
        public ContactTypeDal(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}