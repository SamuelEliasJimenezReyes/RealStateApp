using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Features.Agents.Commands.AgentChangeStatusCommand;
using RealStateApp.Core.Application.Features.Agents.Querys.GetAgentById;
using RealStateApp.Core.Application.Features.Agents.Querys.GetAgentProperty;
using RealStateApp.Core.Application.Features.Agents.Querys.GetAllAgents;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace RealStateApp.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [SwaggerTag("Mantenimiento de Agentes")]
    public class AgentsController : BaseApiController
    {
        
        [Authorize(Roles = "Admin, Developer")]
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary ="Lista",
            Description="obtendremos una lista de todos los agentes existentes"
          
          )]
        public async Task<IActionResult> List()
        {

            return Ok(await Mediator.Send(new GetAllAgentsQuery()));

        }
        
        [Authorize(Roles = "Admin, Developer")]
        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Obtener por Id",
            Description = "a traves de un id obtendremos la data de ese agente"

          )]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await Mediator.Send(new GetAgentByIdQuery { Id = id }));

        }

        [Authorize(Roles = "Admin, Developer")]
        [HttpGet]
        [Route("GetAgentProperty/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Obtener Propiedades del Agente",
            Description = "Mediante un id obtendremos una lista de todas las propiedades asociadas al agente"

          )]
        public async Task<IActionResult> GetAgentProperty(string id)
        {
            return Ok(await Mediator.Send(new GetAgentPropertyQuery { Id = id }));

        }

        [Authorize(Roles = "Admin")]
        [Route("ChangeStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Cambiar Estado",
            Description = "mediante un id y un booleano cambiaremos el estado del agente"

          )]
        public async Task<IActionResult> ChangeStatus([FromQuery]AgentChangeStatusCommand command)
        {
            await Mediator.Send(command);
            return NoContent();

        }
        
       
    }

}

