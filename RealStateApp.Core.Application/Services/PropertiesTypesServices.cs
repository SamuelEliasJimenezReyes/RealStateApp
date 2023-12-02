

using AutoMapper;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.PropertiesTypes;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Services
{
    public class PropertiesTypesServices : GenericService<SavePropertiesTypesVM, PropertiesTypesVM, PropertiesTypes>, IPropertiesTypesService
    {
        private readonly IPropertiesTypesRepository _propertiesTypesRepository;
        private readonly IMapper _mapper;

        public PropertiesTypesServices(IPropertiesTypesRepository propertiesTypesRepository, IMapper mapper) : base(propertiesTypesRepository, mapper)
        {
            _propertiesTypesRepository = propertiesTypesRepository;
            _mapper = mapper;
        }
    }
}
