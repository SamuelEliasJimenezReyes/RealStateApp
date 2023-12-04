

using AutoMapper;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.ImprovementsProperties;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Services
{
    public class PropertiesImprovementsService : GenericService<SavePropertiesImprovementsVM, PropertiesImprovementsVM,PropertiesImprovements>, IPropertiesImprovementsService
    {
        private readonly IPropertiesImprovementsRepository _propertiesImprovementsRepository;
        private readonly IMapper _mapper;

        public PropertiesImprovementsService(IPropertiesImprovementsRepository propertiesImprovementsRepository,
            IMapper mapper) : base (propertiesImprovementsRepository, mapper)
        {
            _propertiesImprovementsRepository = propertiesImprovementsRepository;
            _mapper = mapper;
        }
    }
}
