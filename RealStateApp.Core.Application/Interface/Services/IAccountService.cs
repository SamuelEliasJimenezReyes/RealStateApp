using RealStateApp.Core.Application.Dtos.Account;


namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);
        Task<UserDTO> GetUserById(string UserId);
        Task<List<UserDTO>> GetAllUsers();
        Task SignOutAsync();
    }
}
