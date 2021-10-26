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

        public async Task<Guid> CreateNewPerson(PersonDto model)
        {
            try
            {
                Guid uuid = Guid.NewGuid();

                Person person = new Person()
                {
                    UUID = uuid,
                    Name = model.Name,
                    Surname = model.Surname,
                    Company = model.Company
                };

                unitOfWork.Person.Insert(person);

                await unitOfWork.CommitAsync();

                return uuid;
            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }

        public async Task DeletePerson(Guid uuid)
        {
            try
            {
                Person person = await unitOfWork.Person
                    .Select(x => x.UUID == uuid)
                    .Include(x => x.PersonContacts)
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

        public async Task EditPerson(PersonDto model)
        {
            try
            {
                Person person = await unitOfWork.Person
                    .Select(x => x.UUID == model.UUID)
                    .FirstOrDefaultAsync();

                if (person != null)
                {
                    person.Name = model.Name;
                    person.Surname = model.Surname;
                    person.Company = model.Company;
                }

                unitOfWork.Person.Update(person);

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
                    .Select(x => new PersonDto
                    {
                        UUID = x.UUID,
                        Name = x.Name,
                        Surname = x.Surname,
                        Company = x.Company
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
                IQueryable<PersonDto> query = unitOfWork.Person.Select()
                    .Select(x => new PersonDto
                    {
                        UUID = x.UUID,
                        Name = x.Name,
                        Surname = x.Surname,
                        Company = x.Company
                    });

                if (pageSize != 0) query = query.Skip(pageIndex * pageSize).Take(pageSize);

                return await query.ToListAsync();
            }
            catch
            {
                await unitOfWork.RollBackAsync();

                throw;
            }
        }
    }
}
