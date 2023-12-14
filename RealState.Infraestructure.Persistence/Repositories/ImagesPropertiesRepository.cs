

using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class ImagesPropertiesRepository : GenericRepository<ImagesProperties>, IImagesPropertiesRepository
    {
        private readonly RealStateContext _context;

        public ImagesPropertiesRepository(RealStateContext context) : base(context) 
        {
            _context = context;
        }

        public override Task<List<ImagesProperties>> GetAllWithIncludeAsync(List<string> properties)
        {
            return base.GetAllWithIncludeAsync(properties); 
        }

        public async Task DeleteImagesProperties(int propertyId, string imagesPath)
        {
            var imagesProperty = _context.ImagesProperties.FirstOrDefault(x => x.PropertiesId == propertyId && x.ImageUrl == imagesPath);
            _context.ImagesProperties.Remove(imagesProperty);
            await _context.SaveChangesAsync();
        }
    }
}
