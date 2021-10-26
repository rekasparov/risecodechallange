using MassTransit;
using RISE.BusinessLayer.Abstract;
using RISE.Shared.Events;
using RISE.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.ReportDetailApi.Consumers
{
    public class ReportCreatedConsumer : IConsumer<ReportCreatedEvent>
    {
        private readonly IReportDetailBl reportDetailBl;
        private readonly ISendEndpointProvider sendEndpointProvider;

        public ReportCreatedConsumer(IReportDetailBl reportDetailBl, ISendEndpointProvider sendEndpointProvider)
        {
            this.reportDetailBl = reportDetailBl;
            this.sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Consume(ConsumeContext<ReportCreatedEvent> context)
        {
            try
            {
                await reportDetailBl.CreateReportByReportId(context.Message.ReportCreatedMessage.ReportId);

                ReportDetailCreatedEvent reportDetailCreatedEvent = new ReportDetailCreatedEvent()
                {
                    ReportDetailCreatedMessage = new ReportDetailCreatedEvent.ReportDetailCreatedMessageModel()
                    {
                        ReportId = context.Message.ReportCreatedMessage.ReportId
                    }
                };

                ISendEndpoint sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettingsModel.ReportDetailCreatedQueueName}"));

                await sendEndpoint.Send(reportDetailCreatedEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error={ex.Message}");
            }
        }
    }
}
