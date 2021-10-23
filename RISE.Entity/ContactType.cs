using System;
using System.Collections.Generic;

#nullable disable

namespace RISE.Entity
{
    public partial class ContactType
    {
        public ContactType()
        {
            PersonContacts = new HashSet<PersonContact>();
        }

        public Guid UUID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonContact> PersonContacts { get; set; }
    }
}
