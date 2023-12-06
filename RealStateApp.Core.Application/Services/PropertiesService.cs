using AutoMapper;
using RealStateApp.Core.Application.Helpers;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.ImprovementsProperties;
using RealStateApp.Core.Application.ViewModels.Properties;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Services
{
    public class PropertiesService : GenericService<SavePropertiesVM, PropertiesVM, Properties>, IPropertiesService
    {
        private readonly IPropertiesRepository _PropertiesRepository;
        private readonly IMapper _mapper;
        private readonly IPropertiesImprovementsService _propertiesImprovementsService;

        public PropertiesService(IPropertiesRepository propertiesRepository, 
            IMapper mapper,
            IPropertiesImprovementsService propertiesImprovementsService) : base(propertiesRepository, mapper)
        {
            _PropertiesRepository = propertiesRepository;
            _mapper = mapper;
            _propertiesImprovementsService = propertiesImprovementsService;
        }

        public override async Task<SavePropertiesVM> Add(SavePropertiesVM vm)
        {
            var propertiesList = await base.GetAllViewModel();
            vm.AgentId = "77ab3005-7d85-42e5-8dfa-b3ffdbb7f0f5";

            vm.Code = GenerateUniquecode.GenerateUniqueCode(propertiesList);

            var svm = await base.Add(vm);

            foreach(var improvements in vm.PropertiesImprovementsId)
            {
                var saveImprovementsProperties = new SavePropertiesImprovementsVM
                {
                   PropertiesId = svm.Id,
                   ImprovementId = improvements
                };

                await _propertiesImprovementsService.Add(saveImprovementsProperties);
            }
            
            return svm;
        }
    }
}
