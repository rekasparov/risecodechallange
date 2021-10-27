using RISE.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RISE.Test.TheoryTestDatas
{
    public class CreateNewPersonTestData : TheoryData<PersonDto>
    {
        public CreateNewPersonTestData()
        {
            Add(null);
            Add(new PersonDto()
            {
                Name = "Burak",
                Surname = "Kayabal",
                Company = "NSI"
            });
        }
    }
}
