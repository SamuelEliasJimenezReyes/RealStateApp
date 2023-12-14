

using AutoMapper;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.ImagesProperties;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Services
{
    public class ImagesPropertiesService : GenericService<SaveImagesPropertiesVM, ImagesPropertiesVM , ImagesProperties>, IImagesPropertiesService
    {
        private readonly IImagesPropertiesRepository _imagesPropertiesRepository;
        private readonly IMapper _mapper;

        public ImagesPropertiesService(IImagesPropertiesRepository imagesPropertiesRepository, IMapper mapper) : base(imagesPropertiesRepository, mapper)
        {
            _imagesPropertiesRepository = imagesPropertiesRepository;
            _mapper = mapper;
        }
        
        public async Task<List<string>> GetAllImagesByPropertyId(int id)
        {
            var list = await _imagesPropertiesRepository.GetAllAsync();

           return list.Where(i => i.PropertiesId == id).Select(x => x.ImageUrl).ToList();
        }

        public async Task DeleteImagesProperties(int propertyId, string imagesPath)
        {
            await _imagesPropertiesRepository.DeleteImagesProperties(propertyId, imagesPath);
        }
    }


}
