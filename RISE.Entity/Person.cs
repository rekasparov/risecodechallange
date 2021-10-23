using System;
using System.Collections.Generic;

#nullable disable

namespace RISE.Entity
{
    public partial class Person
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public virtual PersonContact PersonContact { get; set; }
    }
}
