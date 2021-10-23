using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RISE.DataTransferObject
{
    public partial class PersonContactDto
    {
        [Required]
        public Guid PersonId { get; set; }
        [Required]
        public Guid ContactTypeId { get; set; }
        [Required]
        public string Content { get; set; }

        public virtual ContactTypeDto ContactType { get; set; }
        public virtual PersonDto Person { get; set; }
    }
}
