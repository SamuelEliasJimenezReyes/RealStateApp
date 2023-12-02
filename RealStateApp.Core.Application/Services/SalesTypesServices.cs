using AutoMapper;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.SalesTypes;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Services
{
    public class SalesTypesServices : GenericService<SaveSalesTypesVM, SalesTypesVM, SalesTypes>, ISalesTypeService
    {
        private readonly ISalesTypeRepository salesTypeRepository;
        private readonly IMapper _mapper;

        public SalesTypesServices(ISalesTypeRepository salesTypeRepository, IMapper mapper) : base(salesTypeRepository, mapper)
        {
            this.salesTypeRepository = salesTypeRepository;
            _mapper = mapper;
        }
    }
}
