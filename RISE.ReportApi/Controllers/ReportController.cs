using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RISE.BusinessLayer.Abstract;
using RISE.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.ReportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportBl reportBl;

        public ReportController(IReportBl reportBl)
        {
            this.reportBl = reportBl;
        }

        [HttpPost]
        [Route("CreateReport")]
        public async Task<IActionResult> CreateReport()
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    await reportBl.CreateReport();
                }
                catch (Exception ex)
                {
                    responseDataModel.HasError = true;
                    responseDataModel.ErrorMessage = ex.Message;
                }

                return new JsonResult(responseDataModel);
            }
        }

        [HttpGet]
        [Route("GetReportList")]
        public async Task<IActionResult> GetReportList(int pageIndex, int pageSize) 
        {
            using (ResponseDataModel responseDataModel = new ResponseDataModel())
            {
                try
                {
                    responseDataModel.Data = await reportBl.GetReportList(pageIndex, pageSize);
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
