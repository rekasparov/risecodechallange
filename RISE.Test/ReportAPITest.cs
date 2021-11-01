using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RISE.Test
{
    public class ReportAPITest
    {
        private readonly IReportBl reportBl;
        private readonly IReportDetailBl reportDetail;

        [Fact]
        public async Task CreateReport()
        {
            Guid reportId = await reportBl.CreateReport();

            Assert.NotEqual<Guid>(Guid.Empty, reportId);
        }

        [Fact]
        public async Task GetReportList()
        {
            await reportBl.CreateReport();

            List<ReportDto> reportList = await reportBl.GetReportList(0, 0);

            Assert.True(reportList.Count > 0);
        }

        [Fact]
        public async Task GetReportDetailsByReportId()
        {
            Guid reportId = await reportBl.CreateReport();

            Assert.NotEqual<Guid>(Guid.Empty, reportId);

            List<ReportDetailDto> reportDetails = await reportDetail.GetReportDetailsByReportId(reportId);

            Assert.True(reportDetails.Count > 0);
        }
    }
}
