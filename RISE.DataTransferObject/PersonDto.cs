using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RISE.DataTransferObject
{
    public partial class PersonDto
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public virtual PersonContactDto PersonContact { get; set; }
    }
}
