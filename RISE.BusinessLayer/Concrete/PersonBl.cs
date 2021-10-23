﻿using Microsoft.EntityFrameworkCore;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.Entity;
using RISE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.BusinessLayer.Concrete
{
    public class PersonBl : IPersonBl
    {
        private readonly IBaseUnitOfWork unitOfWork;

        public PersonBl(IBaseUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateNewPerson(PersonDto model)
        {
            try
            {
                Person person = new Person()
                {
                    UUID = Guid.NewGuid(),
                    Name = model.Name,
                    Surname = model.Surname,
                    Company = model.Company,
                    PersonContacts = model.PersonContacts.Select(x => new PersonContact
                    {
                        ContactTypeId = x.ContactTypeId,
                        Content = x.Content
                    }).ToList()
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
                Person person = await unitOfWork.Person.Select(x => x.UUID == model.UUID).FirstOrDefaultAsync();

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
                        .ThenInclude(x => x.ContactType)
                    .Select(x => new PersonDto
                    {
                        UUID = x.UUID,
                        Name = x.Name,
                        Surname = x.Surname,
                        Company = x.Company,
                        PersonContacts = x.PersonContacts.Select(y => new PersonContactDto()
                        {
                            PersonId = y.PersonId,
                            ContactTypeId = y.ContactTypeId,
                            Content = y.Content,
                            ContactType = new ContactTypeDto()
                            {
                                UUID = y.ContactType.UUID,
                                Name = y.ContactType.Name
                            }
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
                        .ThenInclude(x => x.ContactType)
                    .Select(x => new PersonDto
                    {
                        UUID = x.UUID,
                        Name = x.Name,
                        Surname = x.Surname,
                        Company = x.Company,
                        PersonContacts = x.PersonContacts.Select(y => new PersonContactDto()
                        {
                            PersonId = y.PersonId,
                            ContactTypeId = y.ContactTypeId,
                            Content = y.Content,
                            ContactType = new ContactTypeDto()
                            {
                                UUID = y.ContactType.UUID,
                                Name = y.ContactType.Name
                            }
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
