using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.Dtos.User;
using RealStateApp.Core.Application.ViewModels.Agents;
using RealStateApp.Core.Application.ViewModels.User;

namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IUserService
    {
        Task ChangeUserStatus(string userID);
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin);
        Task<List<UserDTO>> GetAllUsers();
        Task<AgentVM> GetUserDTOAsync();
        //Task<bool> IsaValidUser(string UserName);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm, bool isForApi);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin, string Role);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm);
        Task<List<AgentVM>> GetAllAgentVM();
        Task SignOutAsync();
        //Task UpdateUser(SaveUserViewModel user);
        Task UpdateUserByUserId(UserDTO dto);
    }
}