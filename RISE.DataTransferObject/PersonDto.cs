using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RISE.DataTransferObject
{
    public partial class PersonDto
    {
        public PersonDto()
        {
            PersonContacts = new HashSet<PersonContactDto>();
        }

        [Required]
        public Guid UUID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Company { get; set; }

        public virtual ICollection<PersonContactDto> PersonContacts { get; set; }
    }
}
