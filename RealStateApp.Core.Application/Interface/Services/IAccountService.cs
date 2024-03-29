﻿using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.Dtos.User;


namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request, bool isForApi);
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin, string user);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);
        Task<UserDTO> GetUserById(string UserId);

        Task<AuthenticationResponse> ChangeStatus(bool status, string id);
        Task<List<UserDTO>> GetAllUsers();
        Task SignOutAsync();
        Task UpdateUser(UserDTO dto);
        Task ChangeUserStatus(string userID);

    }
}
