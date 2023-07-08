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
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UserController(IUserService userService) : ControllerBase
    {
        /// <summary>
        /// Retrieves the preferences of the current user.
        /// </summary>
        /// <returns>The user's preferences.</returns>
        [HttpGet("preferences")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetUserPreferences()
        {
            var preferences = await userService.GetUserPreferences(User.FindFirstValue(ClaimTypes.Name));
            return Ok(preferences);
        }
        /// <summary>
        /// Updates the preferences of the current user.
        /// </summary>
        /// <param name="request">The updated user preferences.</param>
        /// <returns>No content.</returns>
        [HttpPut("preferences")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateUserPreferences(UserPreferencesUpdateRequest request)
        {
            await userService.UpdateUserPreferences(request, User.FindFirstValue(ClaimTypes.Name));
            return NoContent();
        }
    }
}
