
using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.Api.SalesTypes;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RealStateApp.Core.Application.Features.SalesTypes.Queries.GetSalesTypeById
{

    public class GetSalesTypeByIdQuery : IRequest<Response<SalesTypesDTO>>
    {
        [SwaggerParameter(Description = "Id Del tipo de venta a obtener")]
        public int Id { get; set; }
    }

    public class GetSalesTypeByIdQueryHandler : IRequestHandler<GetSalesTypeByIdQuery, Response<SalesTypesDTO>>
    {
        private readonly ISalesTypeRepository _salesTypeRepository;
        private readonly IMapper _mapper;
        public GetSalesTypeByIdQueryHandler(ISalesTypeRepository salesTypeRepository, IMapper mapper)
        {
            _salesTypeRepository = salesTypeRepository;
            _mapper = mapper;
        }
        public async Task<Response<SalesTypesDTO>> Handle(GetSalesTypeByIdQuery request, CancellationToken cancell)
        {
            var type = await GetById(request.Id);
            if (type == null) throw new ApiException("SalesType not found", (int)HttpStatusCode.NotFound);
            return new Response<SalesTypesDTO>(type);
        }

        private async Task<SalesTypesDTO> GetById(int id)
        {
            var type = await _salesTypeRepository.GetByIdAsync(id);
            if (type == null) throw new ApiException("SalesType not found", (int)HttpStatusCode.NotFound);

            SalesTypesDTO dto = new SalesTypesDTO
            {
                Id = type.Id,
                Description = type.Description,
                Name = type.Name,

            };

            return dto;
        }


    }
}
