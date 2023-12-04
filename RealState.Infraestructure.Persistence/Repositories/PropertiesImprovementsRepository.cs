

using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class PropertiesImprovementsRepository : GenericRepository<PropertiesImprovements>, IPropertiesImprovementsRepository
    {
        public PropertiesImprovementsRepository(RealStateContext dbContext) : base(dbContext)
        {
        }
    }
}
