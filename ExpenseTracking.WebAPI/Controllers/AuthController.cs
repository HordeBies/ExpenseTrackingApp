using ExpenseTracking.Core.DTO;
using ExpenseTracking.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AuthController(IUserService userService) : ControllerBase
    {
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="request">The registration request.</param>
        /// <returns>The registration response.</returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserRegisterResponse>> Register([FromBody] UserRegisterRequest request)
        {
            bool isUserNameUnique = await userService.IsUniqueUser(request.Email);
            if (!isUserNameUnique)
            {
                return BadRequest("Username already taken!");
            }
            try
            {
                var response = await userService.Register(request);
                return response;
            }
            catch (Exception ex) // Weak password, etc.
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Generates a JWT Token for authentication.
        /// </summary>
        /// <param name="request">The user credentials.</param>
        /// <returns>The token response.</returns>
        [HttpPost("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserTokenResponse>> GetToken([FromBody] UserTokenRequest request)
        {
            var tokenResponse = await userService.GetToken(request);
            if (string.IsNullOrEmpty(tokenResponse.Token))
            {
                return Unauthorized();
            }
            return tokenResponse;
        }

    }
}
