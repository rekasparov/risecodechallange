using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.Test.TheoryTestDatas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RISE.Test
{
    public class PersonAPITest
    {
        private readonly IPersonBl personBl;
        private readonly IPersonContactBl personContactBl;

        [Theory, ClassData(typeof(CreateNewPersonTestData))]
        public async Task CreateNewPerson(PersonDto model)
        {
            Assert.NotNull(model);

            Guid personId = await personBl.CreateNewPerson(new PersonDto()
            {
                Name = model.Name,
                Surname = model.Surname,
                Company = model.Company
            });

            Assert.NotEqual<Guid>(Guid.Empty, personId);
        }

        [Theory, ClassData(typeof(DeletePersonTestData))]
        public async Task DeletePerson(Guid? uuid)
        {
            Assert.NotEqual<Guid>(Guid.Empty, uuid.Value);
            Assert.NotNull(uuid);

            await personBl.DeletePerson(uuid.Value);

            Assert.Null(await personBl.GetPersonByUUID(uuid.Value));
        }

        [Fact]
        public async Task GetPersonList()
        {
            await personBl.CreateNewPerson(new PersonDto()
            {
                UUID = Guid.NewGuid(),
                Name = "Test",
                Surname = "Test",
                Company = "Test"
            });

            List<PersonDto> personList = await personBl.GetPersonList(0, 0);

            Assert.True(personList.Count > 0);
        }

        [Theory, ClassData(typeof(GetPersonByUUIDTestData))]
        public async Task GetPersonByUUID(Guid? uuid)
        {
            Assert.NotEqual<Guid>(Guid.Empty, uuid.Value);
            Assert.NotNull(uuid);

            PersonDto person = await personBl.GetPersonByUUID(uuid.Value);

            Assert.NotNull(person);

            List<PersonContactDto> personContact = await personContactBl.GetPersonContactsByPersonId(person.UUID);

            Assert.True(personContact.Count > 0);
        }

        [Theory, ClassData(typeof(CreateNewPersonContactTestData))]
        public async Task CreateNewPersonContact(PersonContactDto model)
        {
            Assert.NotNull(model);

            Guid personId = await personContactBl.CreateNewPersonContact(new PersonContactDto()
            {
                PersonId = model.PersonId,
                PhoneNumber = model.PhoneNumber,
                EmailAddress = model.EmailAddress,
                Location = model.Location
            });

            Assert.NotEqual<Guid>(Guid.Empty, personId);
        }

        [Theory, ClassData(typeof(DeletePersonContactTestData))]
        public async Task DeletePersonContact(Guid? uuid)
        {
            Assert.NotEqual<Guid>(Guid.Empty, uuid.Value);
            Assert.NotNull(uuid);

            await personContactBl.DeletePersonContact(uuid.Value);

            Assert.Null(await personBl.GetPersonByUUID(uuid.Value));
        }
    }
}
