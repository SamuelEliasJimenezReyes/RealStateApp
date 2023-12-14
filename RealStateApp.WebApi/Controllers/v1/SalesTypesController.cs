using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Features.SalesTypes.Commands.CreateSalesTypes;
using RealStateApp.Core.Application.Features.SalesTypes.Commands.DeleteSalesTypeById;
using RealStateApp.Core.Application.Features.SalesTypes.Commands.UpdateSalesTypes;
using RealStateApp.Core.Application.Features.SalesTypes.Queries.GetAllSalesTypes;
using RealStateApp.Core.Application.Features.SalesTypes.Queries.GetSalesTypeById;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace RealStateApp.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [SwaggerTag("Mantenimiento de Tipo de Ventas")]
    public class SalesTypesController : BaseApiController
    {
        [Authorize(Roles = "Admin, Developer")]
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Obtener todos los tipos de ventas",
            Description = "Podremos ver todos los tipos de ventas"

          )]
        public async Task<IActionResult> List()
        {
            
           return Ok(await Mediator.Send(new GetAllSalesTypesQuery()));
            
        }
        [Authorize(Roles = "Admin, Developer")]
        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Obtener tipo de ventas por id",
            Description = "A traves del id podemos obtener la data del tipo de venta"

          )]
        public async Task<IActionResult> GetById(int id)
        {
            
          return Ok(await Mediator.Send(new GetSalesTypeByIdQuery { Id = id }));
           
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
            Summary = "Creación Tipos de Ventas",
            Description = "aqui creamos los tipos de ventas"

          )]
        public async Task<IActionResult> Create([FromQuery] CreateSalesTypesCommand command)
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
            Summary = "Actualizar tipo de Venta",
            Description = "aqui modificamos un tipo de venta existente"

          )]
        public async Task<IActionResult> Update([FromQuery] UpdateSalesTypesCommand command, int id)
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
            Summary = "Eliminar Tipos de venta",
            Description = "eliminamos un tipo de venta atraves de ID"

          )]
        public async Task<IActionResult> Delete(int id)
        {        
                await Mediator.Send(new DeleteSalesTypeByIdCommand { Id = id });
                return NoContent();

        }
    }
}
