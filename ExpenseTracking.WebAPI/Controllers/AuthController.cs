using ExpenseTracking.Core.DTO;
using ExpenseTracking.Core.ServiceContracts;
using ExpenseTracking.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IUserService userService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserRegisterRequest request)
        {
            bool isUserNameUnique = await userService.IsUniqueUser(request.Email);
            if (!isUserNameUnique)
            {
                return BadRequest("Username already taken!");
            }
            try
            {
                var response = await userService.Register(request);
                return Ok(response);
            }
            catch (Exception ex) // Weak password, etc.
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("token")]
        public async Task<ActionResult> GetToken([FromBody] UserTokenRequest request)
        {
            var tokenResponse = await userService.GetToken(request);
            if (string.IsNullOrEmpty(tokenResponse.Token))
            {
                return Unauthorized();
            }
            return Ok(tokenResponse);
        }

    }
}
