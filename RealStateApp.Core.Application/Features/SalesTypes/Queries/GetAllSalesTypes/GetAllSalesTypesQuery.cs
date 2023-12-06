
using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.SalesTypes;
using RealStateApp.Core.Application.Interface.Repositories;
using System.Runtime.CompilerServices;
using System.Threading;

namespace RealStateApp.Core.Application.Features.SalesTypes.Queries.GetAllSalesTypes
{
    public class GetAllSalesTypesQuery : IRequest<IList<SalesTypesDTO>>
    {

    }

    public class GetAllSalesTypesQueryHandler : IRequestHandler<GetAllSalesTypesQuery, IList<SalesTypesDTO>>
    {
        private readonly ISalesTypeRepository _salesTypeRepository;
        private readonly IMapper _mapper;
        public GetAllSalesTypesQueryHandler(ISalesTypeRepository salesTypeRepository, IMapper mapper)
        {
            _salesTypeRepository = salesTypeRepository;
            _mapper = mapper;
        }
        public async Task<IList<SalesTypesDTO>> Handle(GetAllSalesTypesQuery request, CancellationToken cancell)
        {
            var listTypes = await GetAll();
            return listTypes;
        }

        private async Task<List<SalesTypesDTO>> GetAll()
        {
            var types = await _salesTypeRepository.GetAllAsync();

            var listTypes = types.Select(a => new SalesTypesDTO { 
            
            Id = a.Id,
            Description = a.Description,
            Name = a.Name,         
            
            }).ToList();    

            return listTypes;
        }
     
    }
}
