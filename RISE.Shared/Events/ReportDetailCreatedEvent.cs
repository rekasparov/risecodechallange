using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.Shared.Events
{
    public class ReportDetailCreatedEvent
    {
        public ReportDetailCreatedMessageModel ReportDetailCreatedMessage { get; set; }

        public class ReportDetailCreatedMessageModel
        {
            public Guid ReportId { get; set; }
        }
    }
}
