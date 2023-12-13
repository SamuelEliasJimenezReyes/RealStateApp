

using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.PropertiesTypes;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using System.Collections.Generic;
using System.Net;

namespace RealStateApp.Core.Application.Features.PropertiesTypes.Queries.GetAllPropertiesTypes
{
    public class GetAllPropertiesTypesQuery : IRequest<Response<IList<PropertiesTypesDTO>>>
    {

    }

    public class GetAllPropertiesTypesQueryHandler : IRequestHandler<GetAllPropertiesTypesQuery, Response<IList<PropertiesTypesDTO>>>
    {
        private readonly IPropertiesTypesRepository _propertiesTypesRepository;
        private readonly IMapper _mapper;
        public GetAllPropertiesTypesQueryHandler(IPropertiesTypesRepository propertiesTypesRepository, IMapper mapper)
        {
            _propertiesTypesRepository = propertiesTypesRepository;
            _mapper = mapper;
        }
        public async Task<Response<IList<PropertiesTypesDTO>>> Handle(GetAllPropertiesTypesQuery request, CancellationToken cancell)
        {
            var listTypes = await GetAll();
            if (listTypes.Count == 0) throw new ApiException("no Content For PropertiesTypes", (int)HttpStatusCode.NoContent);
            
            return new Response <IList<PropertiesTypesDTO>>(listTypes);
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
