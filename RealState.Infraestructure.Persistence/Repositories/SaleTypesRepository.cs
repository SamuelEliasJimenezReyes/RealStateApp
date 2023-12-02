

using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class SaleTypesRepository : GenericRepository<SalesTypes>, ISalesTypeRepository
    {
        public SaleTypesRepository(RealStateContext dbContext) : base(dbContext)
        {
        }
    }
}
