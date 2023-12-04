

namespace RealStateApp.Core.Application.Features.Properties.Queries.GetAllProperties
{
    public class GetAllPropertiesParameter
    {
        public int? SalesTypeId { get; set; }
        public int? PropertiesTypeId { get; set; }
        public int? ImprovementsTypeId { get; set; }
        public string? AgentId { get; set; }
    }
}
