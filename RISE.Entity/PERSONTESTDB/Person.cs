using System;
using System.Collections.Generic;

#nullable disable

namespace RISE.Entity.PERSONTESTDB
{
    public partial class Person
    {
        public Person()
        {
            PersonContacts = new HashSet<PersonContact>();
        }

        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public virtual ICollection<PersonContact> PersonContacts { get; set; }
    }
}
