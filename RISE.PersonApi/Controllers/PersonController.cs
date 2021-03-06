using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.PersonApi.Models;
using RISE.Shared.Events;
using RISE.Shared.Models;
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
        private readonly ISendEndpointProvider sendEndpointProvider;

        public PersonController(IPersonBl personBl, ISendEndpointProvider sendEndpointProvider)
        {
            this.personBl = personBl;
            this.sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        [Route("CreateNewPerson")]
        public async Task<IActionResult> CreateNewPerson(CreateNewPersonModel model)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    Guid personId = await personBl.CreateNewPerson(new PersonDto()
                    {
                        Name = model.Person.Name,
                        Surname = model.Person.Surname,
                        Company = model.Person.Company
                    });

                    PersonCreatedEvent personCreatedEvent = new PersonCreatedEvent()
                    {
                        PersonCreatedMessages = model.PersonContacts.Select(x => new PersonCreatedEvent.PersonCreatedMessageModel
                        {
                            PersonId = personId,
                            EmailAddress = x.EmailAddress,
                            Location = x.Location,
                            PhoneNumber = x.PhoneNumber
                        }).ToList()
                    };

                    ISendEndpoint sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettingsModel.PersonCreatedQueueName}"));

                    await sendEndpoint.Send(personCreatedEvent);
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
                    await personBl.DeletePerson(model.UUID);
                }
                catch (Exception ex)
                {
                    responseDataModel.HasError = true;
                    responseDataModel.ErrorMessage = ex.Message;
                }

                return new JsonResult(responseDataModel);
            }
        }

        [HttpPut]
        [Route("EditPerson")]
        public async Task<IActionResult> EditPerson(EditPersonModel model)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    await personBl.EditPerson(new PersonDto()
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
        public async Task<IActionResult> GetPersonByUUID(Guid uuid)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    responseDataModel.Data = await personBl.GetPersonByUUID(uuid);
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
