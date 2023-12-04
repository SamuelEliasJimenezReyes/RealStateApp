

using RealStateApp.Core.Application.ViewModels.Improvements;

namespace RealStateApp.Core.Application.Dtos.Api.Properties
{
    public class PropertiesDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public double LandSizeMeter { get; set; }
        public int RoomQuantity { get; set; }
        public string Description { get; set; }
        public int BathroomQuantity { get; set; }
        public string AgentId { get; set; }
        public string AgentName { get; set; }
        public string PropertiesType { get; set; }

        public string SaleType { get; set; }
        public List<ImprovementsVM> Improvements { get; set; }

      
    }
}
