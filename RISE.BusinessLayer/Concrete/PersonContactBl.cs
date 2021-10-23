using Microsoft.EntityFrameworkCore;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.Entity;
using RISE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.BusinessLayer.Concrete
{
    public class PersonContactBl : IPersonContactBl
    {
        private readonly IBaseUnitOfWork unitOfWork;

        public PersonContactBl(IBaseUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateNewPersonContact(PersonContactDto model)
        {
            try
            {
                PersonContact personContact = new PersonContact()
                {
                    PersonId = model.PersonId,
                    PhoneNumber = model.PhoneNumber,
                    EmailAddress = model.EmailAddress,
                    Location = model.Location
                };

                unitOfWork.PersonContact.Insert(personContact);

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }

        public async Task DeletePersonContact(PersonContactDto model)
        {
            try
            {
                PersonContact personContact = await unitOfWork.PersonContact.Select(x => x.PersonId == model.PersonId).FirstOrDefaultAsync();

                if (personContact != null) unitOfWork.PersonContact.Delete(personContact);

                await unitOfWork.CommitAsync();

            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }
    }
}
