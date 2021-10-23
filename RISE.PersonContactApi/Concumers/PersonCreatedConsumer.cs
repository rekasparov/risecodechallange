using MassTransit;
using RISE.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.PersonContactApi.Concumers
{
    public class PersonCreatedConsumer : IConsumer<PersonCreatedEvent>
    {
        public Task Consume(ConsumeContext<PersonCreatedEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
