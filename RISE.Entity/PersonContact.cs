using System;
using System.Collections.Generic;

#nullable disable

namespace RISE.Entity
{
    public partial class PersonContact
    {
        public Guid PersonId { get; set; }
        public Guid ContactTypeId { get; set; }
        public string Content { get; set; }

        public virtual ContactType ContactType { get; set; }
        public virtual Person Person { get; set; }
    }
}
