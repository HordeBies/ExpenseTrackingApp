using Azure.Core;
using ExpenseTracking.Core.DTO;
using ExpenseTracking.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExpenseTracking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        [HttpGet("transaction-summary")]
        [Authorize]
        public async Task<ActionResult> GetUserTransactionSummary()
        {
            return Ok();
        }
        [HttpGet("preferences")]
        [Authorize]
        public async Task<ActionResult> GetUserPreferences()
        {
            return Ok();
        }
        [HttpPut("preferences")]
        [Authorize]
        public async Task<ActionResult> UpdateUserPreferences()
        {
            return Ok();
        }
    }
}
