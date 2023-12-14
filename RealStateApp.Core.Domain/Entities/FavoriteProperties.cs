

using RealStateApp.Core.Domain.Common;

namespace RealStateApp.Core.Domain.Entities
{
    public class FavoriteProperties : BaseEntity
    {
        public string ClientId { get; set; }
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }

    }
}
