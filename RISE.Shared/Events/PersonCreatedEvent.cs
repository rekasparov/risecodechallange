using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.Shared.Events
{
    public class PersonCreatedEvent
    {
        public PersonCreatedMessageModel PersonCreatedMessage { get; set; }

        public class PersonCreatedMessageModel 
        {
        
        }
    }
}
