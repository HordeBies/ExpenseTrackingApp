using ExpenseTracking.Core.DTO;
using ExpenseTracking.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTracking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet("preferences")]
        public async Task<ActionResult> GetUserPreferences()
        {
            var preferences = await userService.GetUserPreferences(User.FindFirstValue(ClaimTypes.Name));
            return Ok(preferences);
        }
        [HttpPut("preferences")]
        public async Task<ActionResult> UpdateUserPreferences(UserPreferencesUpdateRequest request)
        {
            await userService.UpdateUserPreferences(request, User.FindFirstValue(ClaimTypes.Name));
            return Ok();
        }
    }
}
