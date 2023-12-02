using RealStateApp.Core.Domain.Common;

namespace RealStateApp.Core.Domain.Entities
{
    public class Improvements : BaseEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public ICollection<PropertiesImprovements> PropertiesImprovements { get; set; }
    }
}
