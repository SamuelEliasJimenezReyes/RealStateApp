

namespace RealStateApp.Core.Domain.Entities
{
    public class PropertyImprovents
    {
        public int PropertyId { get; set; }
        public Properties Properties { get; set; }
        public int ImproventId { get; set; }
        public Improvements improvements { get; set; }
    }
}
