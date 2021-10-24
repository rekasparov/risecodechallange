using MassTransit;
using RISE.BusinessLayer.Abstract;
using RISE.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.ReportDetailApi.Consumers
{
    public class ReportCreatedConsumer : IConsumer<ReportCreatedEvent>
    {
        private readonly IReportDetailBl reportDetailBl;
        private readonly IPublishEndpoint publishEndpoint;

        public ReportCreatedConsumer(IReportDetailBl reportDetailBl, IPublishEndpoint publishEndpoint)
        {
            this.reportDetailBl = reportDetailBl;
            this.publishEndpoint = publishEndpoint;
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

                await publishEndpoint.Publish(reportDetailCreatedEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error={ex.Message}");
            }
        }
    }
}
