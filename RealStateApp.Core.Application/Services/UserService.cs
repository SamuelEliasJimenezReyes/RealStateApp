using AutoMapper;
using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.ViewModels.User;
using RealStateApp.Core.Application.Dtos.User;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Agents;
using Microsoft.AspNetCore.Http;
using RealStateApp.Core.Application.Helpers;
using RealStateApp.Core.Application.ViewModels.Admin;

namespace RealStateApp.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IAgentImagesService _agentImagesService;
        private readonly AuthenticationResponse _userSession;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IAccountService accountService,
            IMapper mapper,
            IAgentImagesService agentImagesService, 
            AuthenticationResponse userSession, 
            IHttpContextAccessor httpContextAccessor)
        {
            _accountService = accountService;
            _mapper = mapper;
            _agentImagesService = agentImagesService;
            _httpContextAccessor = httpContextAccessor;
            _userSession = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

        }




        public async Task ChangeUserStatus(string userID)
        {
            await _accountService.ChangeUserStatus(userID);
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel vm, bool isForApi)
        {
            AuthenticationRequest loginRequest = _mapper.Map<AuthenticationRequest>(vm);
            AuthenticationResponse userResponse = await _accountService.AuthenticateAsync(loginRequest,isForApi );
            return userResponse;
        }
        //public async Task UpdateUser(SaveAdminViewModel user)
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

        public async Task<AgentVM> GetUserDTOAsync()
        {
            var list = await GetAllAgentVM();
            return list.FirstOrDefault(x => x.UserId == _userSession.Id);
        }

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
        public async Task<List<SaveAdminViewModel>> GetAllAdminVM()
        {
            var userDTOList = await _accountService.GetAllUsers();
            var agentList = userDTOList.Where(x => x.Roles.Contains("Admin")).ToList();
            var agentVMList = new List<SaveAdminViewModel>();
            foreach (var agent in agentList)
            {
                var agentVM = _mapper.Map<SaveAdminViewModel>(agent);
                agentVMList.Add(agentVM);
            }

            return agentVMList;
        }
        public async Task UpdateUserByUserId(UserDTO dto)
        {
            await _agentImagesService.UpdateAgentImagesByAgentId(_userSession.Id, dto.ImagePath);
            dto.UserId = _userSession.Id;
            await _accountService.UpdateUser(dto);
        }
    }
    }
