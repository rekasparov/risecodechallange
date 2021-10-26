using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RISE.BusinessLayer.Abstract;
using RISE.Shared.Events;
using RISE.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.ReportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportBl reportBl;
        private readonly ISendEndpointProvider sendEndpointProvider;

        public ReportController(IReportBl reportBl, ISendEndpointProvider sendEndpointProvider)
        {
            this.reportBl = reportBl;
            this.sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        [Route("CreateReport")]
        public async Task<IActionResult> CreateReport()
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    Guid reportId = await reportBl.CreateReport();

                    ReportCreatedEvent reportCreatedEvent = new ReportCreatedEvent()
                    {
                        ReportCreatedMessage = new ReportCreatedEvent.ReportCreatedMessageModel()
                        {
                            ReportId = reportId
                        }
                    };

                    ISendEndpoint sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettingsModel.ReportCreatedQueueName}"));

                    await sendEndpoint.Send(reportCreatedEvent);
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
        [Route("GetReportList")]
        public async Task<IActionResult> GetReportList(int pageIndex, int pageSize)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    responseDataModel.Data = await reportBl.GetReportList(pageIndex, pageSize);
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
