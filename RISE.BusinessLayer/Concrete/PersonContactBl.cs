﻿using Microsoft.EntityFrameworkCore;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.Entity;
using RISE.UnitOfWork.Abstract;
using RISE.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.BusinessLayer.Concrete
{
    public class PersonContactBl : IPersonContactBl
    {
        private readonly IBaseUnitOfWork unitOfWork = new BaseUnitOfWork();

        public async Task CreateNewPersonContact(PersonContactDto model)
        {
            try
            {
                PersonContact personContact = new PersonContact()
                {
                    UUID = Guid.NewGuid(),
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
                PersonContact personContact = await unitOfWork.PersonContact
                    .Select(x => x.UUID == model.UUID)
                    .FirstOrDefaultAsync();

                if (personContact != null) unitOfWork.PersonContact.Delete(personContact);

                await unitOfWork.CommitAsync();

            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }

        public async Task<List<PersonContactDto>> GetPersonContactsByPersonId(Guid personId)
        {
            try
            {
                return await unitOfWork.PersonContact
                    .Select(x => x.PersonId == personId)
                    .Include(x => x.Person)
                    .Select(x => new PersonContactDto()
                    {
                        UUID = x.UUID,
                        PersonId = x.PersonId,
                        PhoneNumber = x.PhoneNumber,
                        EmailAddress = x.EmailAddress,
                        Location = x.Location,
                        Person = new PersonDto()
                        {
                            UUID = x.Person.UUID,
                            Name = x.Person.Name,
                            Surname = x.Person.Surname,
                            Company = x.Person.Company
                        }
                    })
                    .ToListAsync();
            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }
    }
}
