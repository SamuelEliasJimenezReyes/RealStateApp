

using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.PropertiesTypes;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RealStateApp.Core.Application.Features.PropertiesTypes.Queries.GetPropertiesTypeById
{
    public class GetPropertiesTypeByIdQuery : IRequest<Response<PropertiesTypesDTO>>
    {
        [SwaggerParameter(Description = "Id Del tipo de propiedad a obtener")]
        public int Id { get; set; }
    }
   

    public class GetPropertiesTypeByIdQueryHandler : IRequestHandler<GetPropertiesTypeByIdQuery, Response<PropertiesTypesDTO>>
    {
        private readonly IPropertiesTypesRepository _propertiesTypeRepository;
        private readonly IMapper _mapper;
        public GetPropertiesTypeByIdQueryHandler(IPropertiesTypesRepository propertiesTypeRepository, IMapper mapper)
        {
            _propertiesTypeRepository = propertiesTypeRepository;
            _mapper = mapper;
        }
        public async Task<Response<PropertiesTypesDTO>> Handle(GetPropertiesTypeByIdQuery request, CancellationToken cancell)
        {
            var type = await GetById(request.Id);
            if (type == null) throw new ApiException("SalesType not found", (int)HttpStatusCode.NotFound);
            return new Response<PropertiesTypesDTO>(type);
        }

        private async Task<PropertiesTypesDTO> GetById(int id)
        {
            var type = await _propertiesTypeRepository.GetByIdAsync(id);
            if (type == null) throw new ApiException("SalesType not found", (int)HttpStatusCode.NotFound);

            PropertiesTypesDTO dto = new PropertiesTypesDTO
            {
                Id = type.Id,
                Description = type.Description,
                Name = type.Name,

            };

            return dto;
        }


    }
}
