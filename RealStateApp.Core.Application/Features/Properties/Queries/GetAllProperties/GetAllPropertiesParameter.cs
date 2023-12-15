

using Swashbuckle.AspNetCore.Annotations;

namespace RealStateApp.Core.Application.Features.Properties.Queries.GetAllProperties
{
    public class GetAllPropertiesParameter
    {
        [SwaggerParameter(Description = "Id Del tipo de venta")]
        public int? SalesTypeId { get; set; }

        [SwaggerParameter(Description = "Id Del Tipo de propiedad")]
        public int? PropertiesTypeId { get; set; }

        [SwaggerParameter(Description = "Id Del Tipo de Mejora")]
        public int? ImprovementsTypeId { get; set; }

        [SwaggerParameter(Description = "Id Del Agente")]
        public string? AgentId { get; set; }
    }
}
