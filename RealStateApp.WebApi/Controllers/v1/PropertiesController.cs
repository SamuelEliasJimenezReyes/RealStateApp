
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Enums;
using RealStateApp.Core.Application.Features.Properties.Queries.GetAllProperties;
using RealStateApp.Core.Application.Features.Properties.Queries.GetPropertiesByCode;
using RealStateApp.Core.Application.Features.Properties.Queries.GetPropertiesById;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net.Mime;

namespace RealStateApp.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [SwaggerTag("Mantenimiento de Propiedades")]
    public class PropertiesController : BaseApiController
    {
        [Authorize(Roles = "Admin, Developer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Obtener Todo",
            Description = "Obtenemos todas las propiedades "

          )]
        public async Task<IActionResult> Get([FromQuery] GetAllPropertiesParameter filter)
        {         
               
          return Ok(await Mediator.Send(new GetAllPropertiesQuery() {}));
            
        }

        [Authorize(Roles = "Admin, Developer")]
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Obtener por Id",
            Description = "A traves del id obtendremos la data de esa propiedad en especifdico"

          )]
        public async Task<IActionResult> GetById(int id)
        {         
           return Ok(await Mediator.Send(new GetPropertiesByIdQuery { Id = id }));          
        }
       
        [Authorize(Roles = "Admin, Developer")]
        [HttpGet("GetByCode/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Obtener por Codigo",
            Description = "A traves del codigo nos traera la data de la propiedad"

          )]
        public async Task<IActionResult> GetByCode(string code)
        {
            
            return Ok(await Mediator.Send(new GetPropertiesByCodeQuery { Code = code }));
           
                
        }
    }
}
