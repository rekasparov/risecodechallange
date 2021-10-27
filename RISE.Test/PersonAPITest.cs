using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.Test.TheoryTestDatas;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RISE.Test
{
    public class PersonAPITest
    {
        private readonly IPersonBl personBl;

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
        public async Task DeletePerson(Guid uuid)
        {
            Assert.NotEqual<Guid>(Guid.Empty, uuid);

            await personBl.DeletePerson(uuid);
        }
    }
}
