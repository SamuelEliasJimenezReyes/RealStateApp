

using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace RealStateApp.Core.Application.Dtos.Api.Agents
{
    public class ChangeStatusRequest
    {
        [JsonIgnore]
       
        public string Id { get; set; }


        [SwaggerParameter(Description = "Debe colocar un estado al agente")]
        public bool Status { get; set; }

    }
}
