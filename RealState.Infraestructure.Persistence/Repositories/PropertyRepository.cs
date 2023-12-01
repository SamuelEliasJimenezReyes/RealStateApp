using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{

    public class PropertyRepository : GenericRepository<Properties>, IPropertyRepository
    {
        public PropertyRepository(RealStateContext dbContext) : base(dbContext)
        {
        }
    }

}
