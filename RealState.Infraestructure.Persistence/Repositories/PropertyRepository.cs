using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{

    public class PropertiesRepository : GenericRepository<Properties>, IPropertiesRepository
    {
        public PropertiesRepository(RealStateContext dbContext) : base(dbContext)
        {
        }
    }

}
