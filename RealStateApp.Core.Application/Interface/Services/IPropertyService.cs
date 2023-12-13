

using RealStateApp.Core.Application.ViewModels.Properties;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IPropertiesService : IGenericService<SavePropertiesVM, PropertiesVM, Properties>
    {
        public Task<List<PropertiesVM>> GetAllPropertiesVM(PropertiesFilterVM filter);
        public Task<PropertiesVM> GetPropertyByCode(string code);
        public Task AddFavoriteProperties(int propertyId, string clientId);
        Task<List<PropertiesVM>> GetPropertiesForClient();
        Task RemoveFavoriteProperty(string clientId, int propertyId);
        Task<List<PropertiesVM>> GetFavoritePropertiesForClient();
    }
}
