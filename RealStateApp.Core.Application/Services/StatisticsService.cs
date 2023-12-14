using AutoMapper;
using Microsoft.AspNetCore.Http;
using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.Helpers;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Statistics;

namespace RealStateApp.Core.Application.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IMapper _mapper;
        private readonly AuthenticationResponse userSession;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPropertiesService _propertiesService;
        private readonly IUserService _userService;

        public StatisticsService(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPropertiesService propertiesService, IUserService userService)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            userSession = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _propertiesService = propertiesService;
            _userService = userService;
        }

        public async Task<DashBoard> GetDashBoard()
        {
            var propierties = await _propertiesService.GetAllViewModel();
            var activeAgent = await _userService.GetAllAgentVM();
            var inActiveAgent = await _userService.GetAllAgentVM();
            var activeClient = await _userService.GetAllUsers();
            var InActiveClient = await _userService.GetAllUsers();
            var activeDeveloper = await _userService.GetAllUsers();
            var InActiveDeveloper = await _userService.GetAllUsers();


            var statistics = new DashBoard
            {
                Propierties=propierties.Count(),
                ActiveAgents=activeAgent.Where(x=>x.IsActive==true).Count(),
                InActiveAgents= inActiveAgent.Where(x=>x.IsActive==false).Count(),
                ActiveClients= activeClient.Where(x=>x.IsActive==true && x.Roles.Contains("Client")).Count(),
                InActiveClients= InActiveClient.Where(x=>x.IsActive=false && x.Roles.Contains("Client")).Count(),
                ActiveDeveloper= activeDeveloper.Where(x=>x.IsActive==true && x.Roles.Contains("Developer")).Count(),
                InActiveDeveloper=InActiveDeveloper.Where(x=>x.IsActive==false && x.Roles.Contains("Developer")).Count()
            };
            
            return statistics;
        }
    }
}
