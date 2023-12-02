

using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class PropertiesTypesRepository : GenericRepository<PropertiesTypes>, IPropertiesTypesRepository
    {
        public PropertiesTypesRepository(RealStateContext dbContext) : base(dbContext)
        {
        }
    }
}
