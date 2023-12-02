

using RealStateApp.Core.Domain.Common;

namespace RealStateApp.Core.Domain.Entities
{
    public class PropertiesTypes : BaseEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public ICollection<Properties> Properties { get; set; }
    }
}
