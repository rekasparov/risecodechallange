using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.PersonApi.Models
{
    public class DeletePersonModel
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
