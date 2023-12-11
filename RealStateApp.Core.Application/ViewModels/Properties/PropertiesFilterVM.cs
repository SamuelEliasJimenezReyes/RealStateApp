

namespace RealStateApp.Core.Application.ViewModels.Properties
{
    public class PropertiesFilterVM
    {
        public string? PropertyCode { get; set; }
        public int? SalesTypeId { get; set; }
        public int? PropertiesTypeId { get; set; }
        public int? ImprovementsTypeId { get; set; }
        public string? AgentId { get; set; }
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }
        public int? BathroomQuantity { get; set; }
        public int? BedroomQuantity { get; set; }
    }
}
