using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.Shared.Events
{
    public class ReportDetailNotCreatedEvent
    {
        public ReportDetailNotCreatedMessageModel ReportDetailNotCreatedMessage { get; set; }

        public class ReportDetailNotCreatedMessageModel
        {
            public Guid UUID { get; set; }
        }
    }
}
