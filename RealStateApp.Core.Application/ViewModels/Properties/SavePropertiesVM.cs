

namespace RealStateApp.Core.Application.ViewModels.Properties
{
    public class SavePropertiesVM
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public double LandSizeMeter { get; set; }
        public int RoomQuantity { get; set; }
        public string Description { get; set; }
        public int BathroomQuantity { get; set; }
        public string AgentId { get; set; }
        public int PropertyTypeId { get; set; }

        public int SaleTypeId { get; set; }
        public List<int> PropertyImproventsId { get; set; }

        public List<string> ImagesProperties { get; set; }
    }
}