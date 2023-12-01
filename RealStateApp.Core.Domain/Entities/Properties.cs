using RealStateApp.Core.Domain.Common;

namespace RealStateApp.Core.Domain.Entities
{
    public class Properties : BaseEntity
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public double LandSizeMeter { get; set; }
        public int RoomQuantity { get; set; }
        public string Description { get; set; }
        public int BathroomQuantity { get; set; }
        public string AgentId { get; set; }
        public int PropertyTypeId { get; set; }
        public PropertyTypes propertyTypes { get; set; }
        public int SaleTypeId { get; set; }
        public SaleTypes SaleType { get; set; }
        public ICollection<PropertyImprovents> PropertyImprovents { get; set; }
    }
}
