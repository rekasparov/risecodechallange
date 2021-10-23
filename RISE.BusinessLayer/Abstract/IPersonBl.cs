using RISE.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.BusinessLayer.Abstract
{
    public interface IPersonBl
    {
        Task<Guid> CreateNewPerson(PersonDto model);
        Task DeletePerson(PersonDto model);
        Task<List<PersonDto>> GetPersonList(int pageIndex, int pageSize);
        Task<PersonDto> GetPersonByUUID(Guid UUID);
    }
}
