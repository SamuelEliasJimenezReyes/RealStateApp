using Swashbuckle.AspNetCore.Annotations;

namespace RealStateApp.Core.Application.Dtos.Api.Improvements
{
    public class SaveImprovementsDTO
    {
        [SwaggerParameter(Description = "Debe de colocar el nombrew")]
        public string Name { get; set; }

        [SwaggerParameter(Description = "Debe Colocar una descripcion")]
        public string Description { get; set; }

    }
}
