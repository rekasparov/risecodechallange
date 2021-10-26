using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.PersonContactApi.Models;
using RISE.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.PersonContactApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonContactController : ControllerBase
    {
        private readonly IPersonContactBl personContactBl;

        public PersonContactController(IPersonContactBl personContactBl)
        {
            this.personContactBl = personContactBl;
        }

        [HttpGet]
        [Route("GetPersonContactsByPersonId")]
        public async Task<IActionResult> GetPersonContactsByPersonId(Guid personId)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    responseDataModel.Data = await personContactBl.GetPersonContactsByPersonId(personId);
                }
                catch (Exception ex)
                {
                    responseDataModel.HasError = true;
                    responseDataModel.ErrorMessage = ex.Message;
                }

                return new JsonResult(responseDataModel);
            }
        }

        [HttpPost]
        [Route("CreateNewPersonContact")]
        public async Task<IActionResult> CreateNewPersonContact(CreateNewPersonContactModel model)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    await personContactBl.CreateNewPersonContact(new PersonContactDto()
                    {
                        PersonId = model.PersonId,
                        EmailAddress = model.EmailAddress,
                        Location = model.Location,
                        PhoneNumber = model.PhoneNumber
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
        [Route("DeletePersonContact")]
        public async Task<IActionResult> DeletePersonContact(DeletePersonContactModel model)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    await personContactBl.DeletePersonContact(model.UUID);
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
