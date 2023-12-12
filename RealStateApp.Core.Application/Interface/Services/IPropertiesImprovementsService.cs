

using RealStateApp.Core.Application.ViewModels.Improvements;
using RealStateApp.Core.Application.ViewModels.ImprovementsProperties;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IPropertiesImprovementsService : IGenericService<SavePropertiesImprovementsVM, PropertiesImprovementsVM, PropertiesImprovements>
    {
        Task<List<ImprovementsVM>> GetImprovementsByPropertyId(int propertyId);
    }
}
