

using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class ImprovementsRepository : GenericRepository<Improvements>, IImprovementsRepository
    {
        public ImprovementsRepository(RealStateContext dbContext) : base(dbContext)
        {
        }
    }
}
