using MassTransit;
using RISE.BusinessLayer.Abstract;
using RISE.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.ReportApi.Consumers
{
    public class ReportDetailNotCreatedConsumer : IConsumer<ReportDetailNotCreatedEvent>
    {
        private readonly IReportBl reportBl;

        public ReportDetailNotCreatedConsumer(IReportBl reportBl)
        {
            this.reportBl = reportBl;
        }

        public async Task Consume(ConsumeContext<ReportDetailNotCreatedEvent> context)
        {
            try
            {
                await reportBl.DeleteReport(context.Message.ReportDetailNotCreatedMessage.UUID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error={ex.Message}");
            }
        }
    }
}
