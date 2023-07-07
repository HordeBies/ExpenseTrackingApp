using ExpenseTracking.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/debug")]
    public class DebugController(IReportService reportService) : ControllerBase
    {
        [HttpGet("send-daily-reports")]
        public async Task<ActionResult> Test()
        {
            await reportService.SendDailyReports();
            return Ok();
        }
    }
}
