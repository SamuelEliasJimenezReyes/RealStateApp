

using RealStateApp.Core.Domain.Common;

namespace RealStateApp.Core.Domain.Entities
{
    public class ImagesProperties : BaseEntity
    {
        public int PropertiesId { get; set; }

        public string ImageUrl { get; set; }


        //Navigation Properties
        public Properties Properties { get; set; }
        
    }
}
