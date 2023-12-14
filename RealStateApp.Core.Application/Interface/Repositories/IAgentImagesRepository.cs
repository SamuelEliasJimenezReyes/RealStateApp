using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Repositories
{
    public interface IAgentImagesRepository : IGenericRepository<AgentImages>
    {
        Task DeleteAgentImages(string agentId);
        Task UpdateAgentImages(string agentId, string imagesPath);
    }
}
