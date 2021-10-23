using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.Entity
{
    public partial class ReportDetail
    {
        public Guid ReportId { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }

        public virtual Report Report { get; set; }
    }
}
