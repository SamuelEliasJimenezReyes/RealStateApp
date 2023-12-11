

using RealStateApp.Core.Domain.Common;

namespace RealStateApp.Core.Domain.Entities
{
    public class AgentImages : BaseEntity
    {
        public string AgentId { get; set; }
        public string? ImagePath { get; set; }
    }
}
