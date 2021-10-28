using System;
using System.Collections.Generic;

#nullable disable

namespace RISE.Entity.PERSONTESTDB
{
    public partial class PersonContact
    {
        public Guid UUID { get; set; }
        public Guid PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }

        public virtual Person Person { get; set; }
    }
}
