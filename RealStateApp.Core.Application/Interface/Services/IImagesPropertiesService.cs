

using RealStateApp.Core.Application.ViewModels.ImagesProperties;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Services
{

    public interface IImagesPropertiesService : IGenericService<SaveImagesPropertiesVM, ImagesPropertiesVM, ImagesProperties>
    {
        Task<List<string>> GetAllImagesByPropertyId(int id);
        Task DeleteImagesProperties(int propertyId, string imagesPath);
    }

}
