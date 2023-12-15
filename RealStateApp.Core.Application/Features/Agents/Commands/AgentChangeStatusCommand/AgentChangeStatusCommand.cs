
using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Agents;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Features.Improvements.Commands.UpdateImprovement;
using RealStateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net;
using RealStateApp.Core.Application.Interface.Services;

namespace RealStateApp.Core.Application.Features.Agents.Commands.AgentChangeStatusCommand
{
    public class AgentChangeStatusCommand : IRequest<Response<ChangeStatusRequest>>
    {
        [SwaggerParameter(Description = "Id del Agente del que queremos cambiar estado")]
        public string Id { get; set; }

        [SwaggerParameter(Description = "Estado del Agente")]
        public bool Status { get; set; }
    }

    public class AgentChangeStatusCommandHandler : IRequestHandler<AgentChangeStatusCommand, Response<ChangeStatusRequest>>
    {
        private readonly IAccountService _accountService;

        public AgentChangeStatusCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Response<ChangeStatusRequest>> Handle(AgentChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var getuser = await _accountService.GetUserById(request.Id);
            if (getuser == null) throw new ApiException("Agent doest exist", (int)HttpStatusCode.NotFound);

            await _accountService.ChangeStatus(request.Status, request.Id);

       
            return new Response<ChangeStatusRequest>();
        }
    }
}
