using Azure.Core;
using ExpenseTracking.Core.DTO;
using ExpenseTracking.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace ExpenseTracking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController(IUserService userService) : ControllerBase
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
            var preferences = await userService.GetUserPreferences(User.FindFirstValue(ClaimTypes.Name));
            return Ok(preferences);
        }
        [HttpPut("preferences")]
        [Authorize]
        public async Task<ActionResult> UpdateUserPreferences(UserPreferencesUpdateRequest request)
        {
            await userService.UpdateUserPreferences(request, User.FindFirstValue(ClaimTypes.Name));
            return Ok();
        }
    }
}
