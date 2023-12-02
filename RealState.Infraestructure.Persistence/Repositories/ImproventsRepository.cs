

using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class ImproventsRepository : GenericRepository<Improvements>, IImproventRepository
    {
        public ImproventsRepository(RealStateContext dbContext) : base(dbContext)
        {
        }
    }
}
