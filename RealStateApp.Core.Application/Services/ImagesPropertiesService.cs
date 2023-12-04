

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


    }
}
