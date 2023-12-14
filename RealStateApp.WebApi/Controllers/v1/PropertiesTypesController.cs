
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Features.PropertiesTypes.Commands.CreatePropertiesTypes;
using RealStateApp.Core.Application.Features.PropertiesTypes.Commands.DeletePropertiesTypeById;
using RealStateApp.Core.Application.Features.PropertiesTypes.Commands.UpdatePropertiesTypes;
using RealStateApp.Core.Application.Features.PropertiesTypes.Queries.GetAllPropertiesTypes;
using RealStateApp.Core.Application.Features.PropertiesTypes.Queries.GetPropertiesTypeById;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace RealStateApp.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [SwaggerTag("Mantenimiento de Tipo de Propiedades")]
    public class PropertiesTypesController : BaseApiController
    {
        [Authorize(Roles = "Admin, Developer")]
        [HttpGet]
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Obtener Todo",
            Description = "Obtenemos todas los tipos de propiedades"

          )]
        public async Task<IActionResult> List()
        {
            
          return Ok(await Mediator.Send(new GetAllPropertiesTypesQuery()));
           
        }

        [Authorize(Roles = "Admin, Developer")]
        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Obtener por id",
            Description = "Obtenemos un tipo de propiedad a traves de un id"

          )]
        public async Task<IActionResult> GetById(int id)
        {
            
                return Ok(await Mediator.Send(new GetPropertiesTypeByIdQuery { Id = id }));
            
           
        }
        [Authorize(Roles = "Admin")]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Crear un tipo de propiedad",
            Description = "Creamos un tipo de propiedad"

          )]
        public async Task<IActionResult> Create([FromQuery] CreatePropertiesTypesCommand command)
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
            Summary = "Editar un tipo de Propiedad",
            Description = "Modificamos las propiedades del tipo de propiedad"

          )]
        public async Task<IActionResult> Update([FromQuery] UpdatePropertiesTypesCommand command, int id)
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
            Summary = "Eliminar Tipos de Propiedad",
            Description = "A traves de un id borramos un tipo de propiedad"

          )]
        public async Task<IActionResult> Delete(int id)
        {
           
                await Mediator.Send(new DeletePropertiesTypesByIdCommand { Id = id });
                return NoContent();

         

        }
    }
}



