using System;
using System.Collections.Generic;

#nullable disable

namespace RISE.DataTransferObject
{
    public partial class ContactTypeDto
    {
        public ContactTypeDto()
        {
            PersonContacts = new HashSet<PersonContactDto>();
        }

        public Guid UUID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonContactDto> PersonContacts { get; set; }
    }
}
