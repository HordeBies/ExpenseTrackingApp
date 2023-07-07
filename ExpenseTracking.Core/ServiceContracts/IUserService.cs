using ExpenseTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Core.ServiceContracts
{
    public interface IUserService
    {
        Task<bool> IsUniqueUser(string username);
        Task<UserTokenResponse> GetToken(UserTokenRequest loginRequest);
        Task<UserRegisterResponse> Register(UserRegisterRequest registerRequest);
        Task <UserPreferencesReponse> GetUserPreferences(string userId);
        Task UpdateUserPreferences(UserPreferencesUpdateRequest request, string userId);

    }
}
