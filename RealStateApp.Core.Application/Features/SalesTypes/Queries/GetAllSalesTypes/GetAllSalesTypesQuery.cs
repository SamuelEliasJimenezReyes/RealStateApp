
using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.Api.SalesTypes;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using System.Net;


namespace RealStateApp.Core.Application.Features.SalesTypes.Queries.GetAllSalesTypes
{
    public class GetAllSalesTypesQuery : IRequest<Response<IList<SalesTypesDTO>>>
    {

    }

    public class GetAllSalesTypesQueryHandler : IRequestHandler<GetAllSalesTypesQuery, Response<IList<SalesTypesDTO>>>
    {
        private readonly ISalesTypeRepository _salesTypeRepository;
        private readonly IMapper _mapper;
        public GetAllSalesTypesQueryHandler(ISalesTypeRepository salesTypeRepository, IMapper mapper)
        {
            _salesTypeRepository = salesTypeRepository;
            _mapper = mapper;
        }
        public async Task<Response<IList<SalesTypesDTO>>> Handle(GetAllSalesTypesQuery request, CancellationToken cancell)
        {
            var listTypes = await GetAll();
            
            
                
            
            return new Response<IList<SalesTypesDTO>>(listTypes);
        }

        private async Task<List<SalesTypesDTO>> GetAll()
        {
            var types = await _salesTypeRepository.GetAllAsync();
            if (types.Count == 0) throw new ApiException("no Content For SalesTypes", (int)HttpStatusCode.NoContent);
            var listTypes = types.Select(a => new SalesTypesDTO { 
            
            Id = a.Id,
            Description = a.Description,
            Name = a.Name,         
            
            }).ToList();    

            return listTypes;
        }
     
    }
}
