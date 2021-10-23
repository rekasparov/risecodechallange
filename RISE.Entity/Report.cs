using System;
using System.Collections.Generic;

#nullable disable

namespace RISE.Entity
{
    public partial class Report
    {
        public Guid UUID { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Status { get; set; }

        public virtual ReportDetail ReportDetail { get; set; }
    }
}
