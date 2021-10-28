using System;
using System.Collections.Generic;

#nullable disable

namespace RISE.Entity.REPORTTESTDB
{
    public partial class Report
    {
        public Report()
        {
            ReportDetails = new HashSet<ReportDetail>();
        }

        public Guid UUID { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<ReportDetail> ReportDetails { get; set; }
    }
}
