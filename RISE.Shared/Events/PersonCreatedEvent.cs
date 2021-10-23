using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.Shared.Events
{
    public class PersonCreatedEvent
    {
        public List<PersonCreatedMessageModel> PersonCreatedMessages { get; set; }

        public class PersonCreatedMessageModel
        {
            public Guid PersonId { get; set; }
            public string EmailAddress { get; set; }
            public string Location { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}
