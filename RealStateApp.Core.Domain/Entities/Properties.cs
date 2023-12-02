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
        public int PropertiesTypeId { get; set; }
       
        public int SaleTypeId { get; set; }

        //Navigation Properties
        public SalesTypes SaleType { get; set; }

        public PropertiesTypes PropertiesTypes { get; set; }
        public ICollection<PropertiesImprovents> PropertiesImprovents { get; set; }

        public ICollection<ImagesProperties> ImagesProperties { get; set; }
        public ICollection<FavoriteProperties>? FavoriteProperties { get; set; }
    }
}
