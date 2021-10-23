using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.DataTransferObject
{
    public partial class ReportDetailDto
    {
        public Guid ReportId { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }

        public virtual ReportDto Report { get; set; }
    }
}
