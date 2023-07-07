using AutoMapper;
using ExpenseTracking.Core.DTO;
using ExpenseTracking.Core.ServiceContracts;
using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.RepositoryContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseTracking.Core.Services
{
    public class UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager, IConfiguration configuration, IMapper mapper) : IUserService
    {
        public async Task<bool> IsUniqueUser(string username)
        {
            return (await userManager.FindByNameAsync(username)) == null;
        }
        public async Task<UserTokenResponse> GetToken(UserTokenRequest request)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            bool isValid = await userManager.CheckPasswordAsync(user, request.Password);
            if (user == null || isValid == false)
            {
                return new UserTokenResponse()
                {
                    Token = "",
                    Id = "",
                    UserName = "",
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["ApiSettings:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            UserTokenResponse response = new()
            {
                Token = tokenHandler.WriteToken(token),
                Id = user.Id,
                UserName = user.UserName
            };
            return response;
        }
        public async Task<UserRegisterResponse> Register(UserRegisterRequest request)
        {
            ApplicationUser user = new()
            {
                UserName = request.Email,
                NormalizedUserName = request.Email.ToUpper(),
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
            };

            var result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                var userToReturn = await userManager.FindByNameAsync(user.UserName);
                return new()
                {
                    Id = userToReturn.Id,
                    UserName = userToReturn.UserName
                };
            }
            else
            {
                throw new AggregateException("Multiple Errors Occured", result.Errors.Select(e => new Exception(e.Description)));
            }
        }

        public async Task<UserPreferencesReponse> GetUserPreferences(string userId)
        {
            var user = await userRepository.GetAsync(r => r.Id == userId, true);
            return mapper.Map<UserPreferencesReponse>(user);
        }

        public async Task UpdateUserPreferences(UserPreferencesUpdateRequest request, string userId)
        {
            var user = await userRepository.GetAsync(r => r.Id == userId, true);
            mapper.Map(request, user);
            await userRepository.SaveAsync();
        }
    }
}
