using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.User;
using RealStateApp.Core.Application.Features.Agent.Queries.GetAllAgent;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateApp.Core.Application.Features.Agent.Queries.GetAllAgentByID
{
    public class GetAllAgentByIDQuery : IRequest<Response<IList<UserDTO>>>
    {
        public string ID { get; set; }
    }
    public class GetAllAgentByIDQueryHandeler : IRequestHandler<GetAllAgentQuery, Response<IList<UserDTO>>>
    {
        private readonly IAccountService _service;
        private readonly IMapper _mapper;

        public GetAllAgentByIDQueryHandeler(IAccountService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Response<IList<UserDTO>>> Handle(GetAllAgentQuery request, CancellationToken cancellationToken)
        {
            var agentList = await _service.GetAllUsers();
            var filter = agentList.Where(x => x.Roles.Contains("Agent")).Where(x=>x.UserId==request.ID);
            if (filter == null) throw new Exception("Agent not found");

            return new Response<IList<UserDTO>>(agentList);
        }

    }
}
