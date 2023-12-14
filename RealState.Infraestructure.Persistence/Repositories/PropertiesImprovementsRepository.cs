

using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class PropertiesImprovementsRepository : GenericRepository<PropertiesImprovements>, IPropertiesImprovementsRepository
    {
        private readonly RealStateContext _context;
        public PropertiesImprovementsRepository(RealStateContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public override Task<List<PropertiesImprovements>> GetAllWithIncludeAsync(List<string> properties)
        {
            return base.GetAllWithIncludeAsync(properties);
        }

        public async Task DeletePropertiesImprovements(int propertyId, int ImprovementsId)
        {
            var pi = _context.PropertiesImprovements.FirstOrDefault(x => x.PropertiesId == propertyId && ImprovementsId == x.ImprovementId);
            _context.PropertiesImprovements.Remove(pi);
            await _context.SaveChangesAsync();
        }
    }
}
