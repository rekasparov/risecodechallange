using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RISE.BusinessLayer.Abstract;
using RISE.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.ReportDetailApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportDetailController : ControllerBase
    {
        private readonly IReportDetailBl reportDetailBl;

        public ReportDetailController(IReportDetailBl reportDetailBl)
        {
            this.reportDetailBl = reportDetailBl;
        }

        [HttpGet]
        [Route("GetReportDetailsByReportId")]
        public async Task<IActionResult> GetReportDetailsByReportId(Guid reportId)
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    responseDataModel.Data = await reportDetailBl.GetReportDetailsByReportId(reportId);
                }
                catch (Exception ex)
                {
                    responseDataModel.HasError = true;
                    responseDataModel.ErrorMessage = ex.Message;
                }

                return new JsonResult(responseDataModel);
            }
        }
    }
}
