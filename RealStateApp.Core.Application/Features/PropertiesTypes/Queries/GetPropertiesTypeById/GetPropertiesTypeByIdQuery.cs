

using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.PropertiesTypes;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealStateApp.Core.Application.Features.PropertiesTypes.Queries.GetPropertiesTypeById
{
    public class GetPropertiesTypeByIdQuery : IRequest<PropertiesTypesDTO>
    {
        public int Id { get; set; }
    }
   

    public class GetPropertiesTypeByIdQueryHandler : IRequestHandler<GetPropertiesTypeByIdQuery, PropertiesTypesDTO>
    {
        private readonly IPropertiesTypesRepository _propertiesTypeRepository;
        private readonly IMapper _mapper;
        public GetPropertiesTypeByIdQueryHandler(IPropertiesTypesRepository propertiesTypeRepository, IMapper mapper)
        {
            _propertiesTypeRepository = propertiesTypeRepository;
            _mapper = mapper;
        }
        public async Task<PropertiesTypesDTO> Handle(GetPropertiesTypeByIdQuery request, CancellationToken cancell)
        {
            var type = await GetById(request.Id);
            if (type == null) throw new Exception("SalesType not found");
            return type;
        }

        private async Task<PropertiesTypesDTO> GetById(int id)
        {
            var type = await _propertiesTypeRepository.GetByIdAsync(id);

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
