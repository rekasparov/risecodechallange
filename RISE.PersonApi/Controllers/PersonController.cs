using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.PersonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonBl personBl;

        public PersonController(IPersonBl personBl)
        {
            this.personBl = personBl;
        }

        [HttpPost]
        [Route("CreateNewPerson")]
        public async Task<IActionResult> CreateNewPerson(CreateNewPersonModel model)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    await personBl.CreateNewPerson(new PersonDto()
                    {
                        Name = model.Person.Name,
                        Surname = model.Person.Surname,
                        Company = model.Person.Company
                    });
                }
                catch (Exception ex)
                {
                    responseDataModel.HasError = true;
                    responseDataModel.ErrorMessage = ex.Message;
                }

                return new JsonResult(responseDataModel);
            }
        }

        [HttpDelete]
        [Route("DeletePerson")]
        public async Task<IActionResult> DeletePerson(DeletePersonModel model)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    await personBl.DeletePerson(new PersonDto()
                    {
                        UUID = model.UUID,
                        Name = model.Name,
                        Surname = model.Surname,
                        Company = model.Company
                    });
                }
                catch (Exception ex)
                {
                    responseDataModel.HasError = true;
                    responseDataModel.ErrorMessage = ex.Message;
                }

                return new JsonResult(responseDataModel);
            }
        }

        [HttpGet]
        [Route("GetPersonList")]
        public async Task<IActionResult> GetPersonList(int pageIndex, int pageSize)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    responseDataModel.Data = await personBl.GetPersonList(pageIndex, pageSize);
                }
                catch (Exception ex)
                {
                    responseDataModel.HasError = true;
                    responseDataModel.ErrorMessage = ex.Message;
                }

                return new JsonResult(responseDataModel);
            }
        }

        [HttpGet]
        [Route("GetPersonByUUID")]
        public async Task<IActionResult> GetPersonByUUID(Guid UUID)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    responseDataModel.Data = await personBl.GetPersonByUUID(UUID);
                }
                catch (Exception ex)
                {
                    responseDataModel.HasError = true;
                    responseDataModel.ErrorMessage = ex.Message;
                }

                return new JsonResult(responseDataModel);
            }
        }
    }
}
