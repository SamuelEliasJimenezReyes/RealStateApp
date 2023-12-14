using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{

    public class PropertiesRepository : GenericRepository<Properties>, IPropertiesRepository
    {
        private readonly RealStateContext _context;

        public PropertiesRepository(RealStateContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public override async Task DeleteAsync(Properties entity)
        {
            entity.IsDeleted = true;
            await UpdateAsync(entity, entity.Id);
            await _context.SaveChangesAsync();
        }

        public override Task<List<Properties>> GetAllWithIncludeAsync(List<string> properties)
        {
            return base.GetAllWithIncludeAsync(properties); 
        }
    }

}
