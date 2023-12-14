
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Repositories
{
    public interface IFavoritePropertiesRepository : IGenericRepository<FavoriteProperties>
    {
        Task<List<int>> GetFavoritePropertiesId(string clientId);
        Task RemoveFavoriteProperty(string clientId, int propertyId);
    }
}
