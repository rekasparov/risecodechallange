using System;
using System.Collections.Generic;

#nullable disable

namespace RISE.DataTransferObject
{
    public partial class ReportDto
    {
        public ReportDto()
        {
            ReportDetails = new HashSet<ReportDetailDto>();
        }

        public Guid UUID { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<ReportDetailDto> ReportDetails { get; set; }
    }
}
