using Microsoft.EntityFrameworkCore;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.Entity;
using RISE.UnitOfWork.Abstract;
using RISE.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.BusinessLayer.Concrete
{
    public class PersonBl : IPersonBl
    {
        private readonly IBaseUnitOfWork unitOfWork = new BaseUnitOfWork();

        public async Task CreateNewPerson(PersonDto model)
        {
            try
            {
                Person person = new Person()
                {
                    UUID = Guid.NewGuid(),
                    Name = model.Name,
                    Surname = model.Surname,
                    Company = model.Company
                };

                unitOfWork.Person.Insert(person);

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }

        public async Task DeletePerson(PersonDto model)
        {
            try
            {
                Person person = await unitOfWork.Person
                    .Select(x => x.UUID == model.UUID)
                    .FirstOrDefaultAsync();

                if (person != null) unitOfWork.Person.Delete(person);

                await unitOfWork.CommitAsync();

            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }

        public async Task<PersonDto> GetPersonByUUID(Guid UUID)
        {
            try
            {
                return await unitOfWork.Person.Select(x => x.UUID == UUID)
                    .Include(x => x.PersonContacts)
                    .Select(x => new PersonDto
                    {
                        UUID = x.UUID,
                        Name = x.Name,
                        Surname = x.Surname,
                        Company = x.Company,
                        PersonContacts = x.PersonContacts.Select(y => new PersonContactDto()
                        {
                            UUID = y.UUID,
                            PersonId = y.PersonId,
                            PhoneNumber = y.PhoneNumber,
                            EmailAddress = y.EmailAddress,
                            Location = y.Location
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();
            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }

        public async Task<List<PersonDto>> GetPersonList(int pageIndex, int pageSize)
        {
            try
            {
                return await unitOfWork.Person.Select()
                    .Include(x => x.PersonContacts)
                    .Select(x => new PersonDto
                    {
                        UUID = x.UUID,
                        Name = x.Name,
                        Surname = x.Surname,
                        Company = x.Company,
                        PersonContacts = x.PersonContacts.Select(y => new PersonContactDto()
                        {
                            UUID = y.UUID,
                            PersonId = y.PersonId,
                            PhoneNumber = y.PhoneNumber,
                            EmailAddress = y.EmailAddress,
                            Location = y.Location
                        }).ToList()
                    })
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
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
