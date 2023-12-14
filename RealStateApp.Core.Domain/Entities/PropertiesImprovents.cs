

using RealStateApp.Core.Domain.Common;

namespace RealStateApp.Core.Domain.Entities
{
    public class PropertiesImprovements : BaseEntity
    {
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
        public int ImprovementId { get; set; }
        public Improvements Improvements { get; set; }
    }
}
