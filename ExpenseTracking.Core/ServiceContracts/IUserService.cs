using ExpenseTracking.Core.DTO;

namespace ExpenseTracking.Core.ServiceContracts
{
    public interface IUserService
    {
        Task<bool> IsUniqueUser(string username);
        Task<UserTokenResponse> GetToken(UserTokenRequest loginRequest);
        Task<UserRegisterResponse> Register(UserRegisterRequest registerRequest);
        Task<UserPreferencesReponse> GetUserPreferences(string userId);
        Task UpdateUserPreferences(UserPreferencesUpdateRequest request, string userId);

    }
}
