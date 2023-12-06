

using AutoMapper;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Improvements;
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

        public async Task<List<ImprovementsVM>> GetImprovementsByPropertyId(int propertyId)
        {
            var list = await _propertiesImprovementsRepository.GetAllWithIncludeAsync(new List<string> { "Improvements" });
            var filterList = list.Where(x => x.PropertiesId == propertyId).ToList();
            var improvementsListVM = new List<ImprovementsVM>();

            foreach(var improvementMxM in filterList)
            {
                var improvementsVM = _mapper.Map<ImprovementsVM>(improvementMxM.Improvements);
                improvementsListVM.Add(improvementsVM);
            }

            return improvementsListVM;
        }

      
    }
}
