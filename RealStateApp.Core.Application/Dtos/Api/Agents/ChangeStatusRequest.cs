

using System.Text.Json.Serialization;

namespace RealStateApp.Core.Application.Dtos.Api.Agents
{
    public class ChangeStatusRequest
    {
        [JsonIgnore]
        public string Id { get; set; }

        public bool Status { get; set; }

    }
}
