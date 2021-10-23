using MassTransit;
using RISE.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.ReportDetailApi.Consumers
{
    public class ReportCreatedConsumer : IConsumer<ReportCreatedEvent>
    {
        public Task Consume(ConsumeContext<ReportCreatedEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
