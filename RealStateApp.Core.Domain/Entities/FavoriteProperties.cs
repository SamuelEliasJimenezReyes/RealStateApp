

namespace RealStateApp.Core.Domain.Entities
{
    public class FavoriteProperties
    {
        public string ClientId { get; set; }
        public int PropertyId { get; set; }
        public Properties Property { get; set; }

    }
}
