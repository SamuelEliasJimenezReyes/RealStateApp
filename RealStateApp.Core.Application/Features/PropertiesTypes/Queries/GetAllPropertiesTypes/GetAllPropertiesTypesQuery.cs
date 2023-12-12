

using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.PropertiesTypes;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealStateApp.Core.Application.Features.PropertiesTypes.Queries.GetAllPropertiesTypes
{
    public class GetAllPropertiesTypesQuery : IRequest<IList<PropertiesTypesDTO>>
    {

    }

    public class GetAllPropertiesTypesQueryHandler : IRequestHandler<GetAllPropertiesTypesQuery, IList<PropertiesTypesDTO>>
    {
        private readonly IPropertiesTypesRepository _propertiesTypesRepository;
        private readonly IMapper _mapper;
        public GetAllPropertiesTypesQueryHandler(IPropertiesTypesRepository propertiesTypesRepository, IMapper mapper)
        {
            _propertiesTypesRepository = propertiesTypesRepository;
            _mapper = mapper;
        }
        public async Task<IList<PropertiesTypesDTO>> Handle(GetAllPropertiesTypesQuery request, CancellationToken cancell)
        {
            var listTypes = await GetAll();
            return listTypes;
        }

        private async Task<List<PropertiesTypesDTO>> GetAll()
        {
            var types = await _propertiesTypesRepository.GetAllAsync();

            var listTypes = types.Select(a => new PropertiesTypesDTO
            {

                Id = a.Id,
                Description = a.Description,
                Name = a.Name,

            }).ToList();

            return listTypes;
        }

    }
}
