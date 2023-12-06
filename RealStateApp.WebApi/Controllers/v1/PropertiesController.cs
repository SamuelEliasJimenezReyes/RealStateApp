
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Features.Properties.Queries.GetAllProperties;

namespace RealStateApp.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PropertiesController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]   
        public async Task<IActionResult> Get([FromQuery] GetAllPropertiesParameter filter)
        {
            try
            {
                return Ok(await mediator.Send(new GetAllPropertiesQuery() {}));
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
