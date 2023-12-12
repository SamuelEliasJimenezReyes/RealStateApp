

using RealStateApp.Core.Application.Dtos.Api.Properties;
using RealStateApp.Core.Application.ViewModels.Properties;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IPropertiesService : IGenericService<SavePropertiesVM, PropertiesVM, Properties>
    {
        public Task<List<PropertiesVM>> GetAllPropertiesVM(PropertiesFilterVM filter);
        public Task<PropertiesVM> GetPropertyByCode(string code);
    }
}
