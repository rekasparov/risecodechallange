using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RISE.Test.TheoryTestDatas
{
    public class GetPersonByUUIDTestData : TheoryData<Nullable<Guid>>
    {
        public GetPersonByUUIDTestData()
        {
            Add(null);
            Add(Guid.Parse("7cdaa31a-049d-4393-83f4-46da5e146a87"));
        }
    }
}
