

using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class SalesTypesRepository : GenericRepository<SalesTypes>, ISalesTypeRepository
    {
        public SalesTypesRepository(RealStateContext dbContext) : base(dbContext)
        {
        }
    }
}
