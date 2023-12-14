

using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Agents;
using RealStateApp.Core.Application.Enums;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.Wrappers;
using System.Net;

namespace RealStateApp.Core.Application.Features.Agents.Querys.GetAllAgents
{
    public class GetAllAgentsQuery : IRequest<Response<IList<AgentsDTO>>>
    {

    }

    public class GetAllAgentsQueryHandler : IRequestHandler<GetAllAgentsQuery, Response<IList<AgentsDTO>>>
    {
        private readonly IAccountService _accountService;

        public GetAllAgentsQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Response<IList<AgentsDTO>>> Handle(GetAllAgentsQuery request, CancellationToken cancellationToken)
        {
            var list = await GetAll();
            if (list.Count == 0) throw new ApiException("no Content For Agents", (int)HttpStatusCode.NoContent);
            return new Response<IList<AgentsDTO>>(list);
        }

        private async Task<List<AgentsDTO>> GetAll()
        {
            var list = await _accountService.GetAllUsers();

            var agents =  list.Where(a => a.Roles.Contains("Agent")).ToList();

            var map = agents.Select(a => new AgentsDTO
            {
                Id = a.UserId,
                Name = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                PhoneNumber = a.Phone,


            }).ToList();

            return map;
        }


            
    }
}
