

namespace RealStateApp.Core.Domain.Entities
{
    public class PropertiesImprovents
    {
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
        public int ImproventId { get; set; }
        public Improvements improvements { get; set; }
    }
}
