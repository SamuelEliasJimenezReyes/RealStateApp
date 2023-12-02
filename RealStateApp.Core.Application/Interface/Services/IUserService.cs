using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.ViewModels.User;

namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IUserService
    {
        //Task ChangeUserStatus(string userName);
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin);
        //Task<List<UserDTO>> GetAllUsers();
        //Task<RegisterRequest> GetUserDTOAsync(string userId);
        //Task<bool> IsaValidUser(string UserName);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm);
        Task SignOutAsync();
        //Task UpdateUser(SaveUserViewModel user);
        //Task<UserDTO> UpdateUserByUserId(UserDTO dto);
    }
}