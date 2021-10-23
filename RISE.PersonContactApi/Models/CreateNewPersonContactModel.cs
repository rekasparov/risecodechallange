using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.PersonContactApi.Models
{
    public class CreateNewPersonContactModel
    {
        public Guid PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }
    }
}
