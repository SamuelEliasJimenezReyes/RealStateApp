
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Enums;
using RealStateApp.Core.Application.Features.Improvements.Commands.CreateImprovements;
using RealStateApp.Core.Application.Features.Improvements.Commands.DeleteImprovementById;
using RealStateApp.Core.Application.Features.Improvements.Commands.UpdateImprovement;
using RealStateApp.Core.Application.Features.Improvements.Queries.GetAllImprovements;
using RealStateApp.Core.Application.Features.Improvements.Queries.GetImprovementById;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace RealStateApp.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [SwaggerTag("Mantenimiento de Tipo de Mejoras")]
    public class ImprovementsController : BaseApiController
    {
        [Authorize(Roles = "Admin, Developer")]
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Lista",
            Description = "Obtendremos la lista "

          )]
        public async Task<IActionResult> List()
        {

            return Ok(await Mediator.Send(new GetAllImprovementsQuery()));
           
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
            Description = "a traves de un Id obtenemos la data de esa mejora"

          )]
        public async Task<IActionResult> GetById(int id)
        {         
                return Ok(await Mediator.Send(new GetImprovementByIdQuery { Id = id }));
                      
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Creación",
            Description = "Se crea una mejora"

          )]
        public async Task<IActionResult> Create(CreateImprovementsCommand command)
        {
           
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await Mediator.Send(command);
                return NoContent();
           

        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Actualizar",
            Description = "Se van a modificar las propiedades de la mejora"

          )]
        public async Task<IActionResult> Update(int id, UpdateImprovementsCommand command)
        {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (id != command.Id)
                {
                    return BadRequest();
                }

                return Ok(await Mediator.Send(command));
           
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("Delete/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Eliminar",
            Description = "A traves del id borraremos la mejora"

          )]
        public async Task<IActionResult> Delete(int id)
        {
            
                await Mediator.Send(new DeleteImprovementsByIdCommand { Id = id });
                return NoContent();

            
       

        }
    }
}