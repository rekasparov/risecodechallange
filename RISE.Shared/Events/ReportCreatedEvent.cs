using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.Shared.Events
{
    public class ReportCreatedEvent
    {
        public ReportCreatedMessageModel ReportCreatedMessage { get; set; }

        public class ReportCreatedMessageModel
        {

        }
    }
}
