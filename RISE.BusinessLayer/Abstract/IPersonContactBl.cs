using RISE.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.BusinessLayer.Abstract
{
    public interface IPersonContactBl
    {
        Task CreateNewPersonContact(PersonContactDto model);
        Task DeletePersonContact(PersonContactDto model);
        Task<List<PersonContactDto>> GetPersonContactsByPersonId(Guid personId);
    }
}
