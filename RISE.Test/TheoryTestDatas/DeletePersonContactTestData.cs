using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RISE.Test.TheoryTestDatas
{
    public class DeletePersonContactTestData : TheoryData<Nullable<Guid>>
    {
        public DeletePersonContactTestData()
        {
            Add(null);
            Add(Guid.NewGuid());
            Add(Guid.Parse("0e7a95ef-e5a0-457c-ab2f-4ae2bc37ec96"));
        }
    }
}
