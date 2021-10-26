using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RISE.DataTransferObject
{
    public partial class PersonContactDto
    {
        public Guid UUID { get; set; }
        public Guid PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }

        public virtual PersonDto Person { get; set; }

        //CUSTOM PROPERTIES
        public string FullName { get; set; }
    }
}
