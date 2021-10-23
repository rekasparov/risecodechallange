﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.PersonContactApi.Models;
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
        public async Task<IActionResult> DeletePersonContact(DeletePersonContactModel model)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    await personContactBl.DeletePersonContact(new PersonContactDto()
                    {
                        UUID = model.UUID,
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
    }
}