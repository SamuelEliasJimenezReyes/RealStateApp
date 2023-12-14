
using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class AgentImagesRepository : GenericRepository<AgentImages>, IAgentImagesRepository
    {
        private readonly RealStateContext _context;
        public AgentImagesRepository(RealStateContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task DeleteAgentImages(string agentId)
        {
            var agentImages =_context.AgentImages.FirstOrDefault(x => x.AgentId == agentId);
            _context.AgentImages.Remove(agentImages);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAgentImages(string agentId, string imagesPath)
        {
            await DeleteAgentImages(agentId);
            AgentImages agentImages = new()
            {
               ImagePath = imagesPath,
               AgentId = agentId
            };
            await AddAsync(agentImages);
        }
    }
}
