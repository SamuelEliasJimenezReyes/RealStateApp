
using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class AgentImagesRepository : GenericRepository<AgentImages>, IAgentImagesRepository
    {
        public AgentImagesRepository(RealStateContext dbContext) : base(dbContext)
        {
        }
    }
}
