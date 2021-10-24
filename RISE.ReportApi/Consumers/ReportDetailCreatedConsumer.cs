using MassTransit;
using RISE.BusinessLayer.Abstract;
using RISE.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.ReportApi.Consumers
{
    public class ReportDetailCreatedConsumer : IConsumer<ReportDetailCreatedEvent>
    {
        private readonly IReportBl reportBl;

        public ReportDetailCreatedConsumer(IReportBl reportBl)
        {
            this.reportBl = reportBl;
        }

        public async Task Consume(ConsumeContext<ReportDetailCreatedEvent> context)
        {
            try
            {
                await reportBl.UpdateStatus(context.Message.ReportDetailCreatedMessage.ReportId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error={ex.Message}");
            }
        }
    }
}
