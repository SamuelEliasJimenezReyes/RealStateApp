

using RealStateApp.Core.Application.ViewModels.Agents;
using RealStateApp.Core.Application.ViewModels.Improvements;

namespace RealStateApp.Core.Application.ViewModels.Properties
{

    public class PropertiesVM
    {
        public string Code { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public double LandSizeMeter { get; set; }
        public int RoomQuantity { get; set; }
        public string Description { get; set; }
        public int BathroomQuantity { get; set; }
        public AgentVM Agent { get; set; }
        public string PropertiesType { get; set; }

        public string SaleType { get; set; }
        public bool IsFavorite { get; set; }
        public List<ImprovementsVM> PropertiesImprovements { get; set; } = new();

        public List<string> ImagesProperties { get; set; } = new();
    }
}
