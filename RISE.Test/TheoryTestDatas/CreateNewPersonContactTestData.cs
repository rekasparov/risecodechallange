using RISE.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RISE.Test.TheoryTestDatas
{
    public class CreateNewPersonContactTestData : TheoryData<PersonContactDto>
    {
        public CreateNewPersonContactTestData()
        {
            Add(null);
            Add(new PersonContactDto()
            {
                UUID = Guid.NewGuid(),
                PersonId = Guid.Parse("7cdaa31a-049d-4393-83f4-46da5e146a87"),
                PhoneNumber = "5551234567",
                EmailAddress = "test@test.com",
                Location = "40.4564,41.8494"
            });
        }
    }
}
