

using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Repositories
{
    public interface IPropertiesImprovementsRepository : IGenericRepository<PropertiesImprovements>
    {
        Task DeletePropertiesImprovements(int propertyId, int ImprovementsId);
    }
}
