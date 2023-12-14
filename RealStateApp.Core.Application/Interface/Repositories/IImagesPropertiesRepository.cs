using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Repositories
{
    public interface IImagesPropertiesRepository : IGenericRepository<ImagesProperties>
    {
        Task DeleteImagesProperties(int propertyId, string imagesPath);
    }
}
