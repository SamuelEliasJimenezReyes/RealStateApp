using AutoMapper;
using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.ViewModels.User;
using RealStateApp.Core.Application.Dtos.User;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Agents;

namespace RealStateApp.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IAgentImagesService _agentImagesService;

        public UserService(IAccountService accountService, IMapper mapper, IAgentImagesService agentImagesService)
        {
            _accountService = accountService;
            _mapper = mapper;
            _agentImagesService = agentImagesService;
        }


        //public async Task ChangeUserStatus(string userName)
        //{
        //    await _accountService.ChangeUserStatus(userName);
        //}

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel vm)
        {
            AuthenticationRequest loginRequest = _mapper.Map<AuthenticationRequest>(vm);
            AuthenticationResponse userResponse = await _accountService.AuthenticateAsync(loginRequest);
            return userResponse;
        }
        //public async Task UpdateUser(SaveUserViewModel user)
        //{
        //    await _accountService.UpdateUser(user);
        //}

        public async Task SignOutAsync()
        {
            await _accountService.SignOutAsync();
        }

        public async Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin, string Role)
        {

            RegisterRequest registerRequest = _mapper.Map<RegisterRequest>(vm);
            var response = await _accountService.RegisterBasicUserAsync(registerRequest, origin, Role);


            return response;

        }

        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            return await _accountService.ConfirmAccountAsync(userId, token);
        }

        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin)
        {
            ForgotPasswordRequest forgotRequest = _mapper.Map<ForgotPasswordRequest>(vm);
            return await _accountService.ForgotPasswordAsync(forgotRequest, origin);
        }

        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm)
        {
            ResetPasswordRequest resetRequest = _mapper.Map<ResetPasswordRequest>(vm);
            return await _accountService.ResetPasswordAsync(resetRequest);
        }

        //public async Task<RegisterRequest> GetUserDTOAsync(string userId)
        //{
        //    return await _accountService.GetUserById(userId);
        //}

        //public async Task<bool> IsaValidUser(string UserName)
        //{
        //    return await _accountService.IsaValidUser(UserName);
        //}

        public async Task<List<UserDTO>> GetAllUsers()
        {
            return await _accountService.GetAllUsers();
        }

        public async Task<List<AgentVM>> GetAllAgentVM()
        {
            var userDTOList = await _accountService.GetAllUsers();
            var agentList = userDTOList.Where(x => x.Roles.Contains("Agent")).ToList();
            var agentVMList = new List<AgentVM>();
           foreach(var agent in agentList)
            {
                var agentVM = _mapper.Map<AgentVM>(agent);
                agentVM.ImagePath = await _agentImagesService.GetImagesByAgentId(agent.UserId);
                agentVMList.Add(agentVM);
            }

            return agentVMList;
        }

        //public async Task<UserDTO> UpdateUserByUserId(UserDTO dto)
        //{
        //    return await _accountService.UpdateUser(dto);
        //}
    }
}
