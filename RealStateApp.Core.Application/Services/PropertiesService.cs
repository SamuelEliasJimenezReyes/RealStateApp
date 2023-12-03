

using AutoMapper;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Properties;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Services
{
    public class PropertiesService : GenericService<SavePropertiesVM, PropertiesVM, Properties>, IPropertiesService
    {
        private readonly IPropertiesRepository _PropertiesRepository;
        private readonly IMapper _mapper;


        public PropertiesService(IPropertiesRepository PropertiesRepository, IMapper mapper) : base(PropertiesRepository, mapper)
        {
            _PropertiesRepository = PropertiesRepository;
            _mapper = mapper;
        }
    }
}
