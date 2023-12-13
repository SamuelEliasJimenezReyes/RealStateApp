
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Enums;
using RealStateApp.Core.Application.Features.Properties.Queries.GetAllProperties;
using RealStateApp.Core.Application.Features.Properties.Queries.GetPropertiesByCode;
using RealStateApp.Core.Application.Features.Properties.Queries.GetPropertiesById;
using System.Collections.Generic;

namespace RealStateApp.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PropertiesController : BaseApiController
    {
        [Authorize(Roles = "Admin, Developer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] GetAllPropertiesParameter filter)
        {         
               
          return Ok(await Mediator.Send(new GetAllPropertiesQuery() {}));
            
        }

        [Authorize(Roles = "Admin, Developer")]
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {         
           return Ok(await Mediator.Send(new GetPropertiesByIdQuery { Id = id }));          
        }
       
        [Authorize(Roles = "Admin, Developer")]
        [HttpGet("GetByCode/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCode(string code)
        {
            
            return Ok(await Mediator.Send(new GetPropertiesByCodeQuery { Code = code }));
           
                
        }
    }
}
