using MassTransit;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.PersonContactApi.Concumers
{
    public class PersonCreatedConsumer : IConsumer<PersonCreatedEvent>
    {
        private readonly IPersonContactBl personContactBl;

        public PersonCreatedConsumer(IPersonContactBl personContactBl)
        {
            this.personContactBl = personContactBl;
        }

        public async Task Consume(ConsumeContext<PersonCreatedEvent> context)
        {
            try
            {
                foreach (var personCreatedMessage in context.Message.PersonCreatedMessages)
                {
                    await personContactBl.CreateNewPersonContact(new PersonContactDto()
                    {
                        PersonId = personCreatedMessage.PersonId,
                        EmailAddress = personCreatedMessage.EmailAddress,
                        Location = personCreatedMessage.Location,
                        PhoneNumber = personCreatedMessage.PhoneNumber
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error={ex.Message}");
            }
        }
    }
}
