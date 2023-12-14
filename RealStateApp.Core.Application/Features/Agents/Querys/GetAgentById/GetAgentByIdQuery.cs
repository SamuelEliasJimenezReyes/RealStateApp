

using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Agents;
using RealStateApp.Core.Application.Dtos.Api.Improvements;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.Wrappers;
using System.Net;

namespace RealStateApp.Core.Application.Features.Agents.Querys.GetAgentById
{
    public class GetAgentByIdQuery : IRequest<Response<AgentsDTO>>
    {
        
        public string Id { get; set; } 
    }

    public class GetAgentByIdQueryHandler : IRequestHandler<GetAgentByIdQuery, Response<AgentsDTO>>
    {
        private readonly IAccountService _accountService;

        public GetAgentByIdQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Response<AgentsDTO>> Handle(GetAgentByIdQuery request, CancellationToken cancellationToken)
        {
            var get = await GetById(request.Id);

            if (get == null) throw new ApiException("Agents not found", (int)HttpStatusCode.NotFound);

            return new Response<AgentsDTO>(get);
        }

        private async Task<AgentsDTO> GetById(string id)
        {
            var get = await _accountService.GetUserById(id);

            if (get == null) throw new ApiException("Agent not found", (int)HttpStatusCode.NotFound);

            AgentsDTO dto = new AgentsDTO
            {
                Id = get.UserId,
                Name = get.FirstName,
                LastName = get.LastName,
                Email = get.Email,
                PhoneNumber = get.Phone,
                // PropiertiesAmount 
            };

            return dto;

            

        }
    }
}
