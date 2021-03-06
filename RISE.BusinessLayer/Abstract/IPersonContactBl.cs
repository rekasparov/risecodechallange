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
        Task<Guid> CreateNewPersonContact(PersonContactDto model);
        Task DeletePersonContact(Guid uuid);
        Task<List<PersonContactDto>> GetPersonContactsByPersonId(Guid personId);
        Task<List<string>> GetLocationList();
        Task<int> GetPersonCountByLocation(string location);
        Task<int> GetPhoneNumberCountByLocation(string location);
    }
}
