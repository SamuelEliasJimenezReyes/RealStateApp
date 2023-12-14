
using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Properties;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.Wrappers;
using System.Net;

namespace RealStateApp.Core.Application.Features.Properties.Queries.GetAllProperties
{
    public class GetAllPropertiesQuery : IRequest<Response<IList<PropertiesDTO>>>
    {
        public int? SalesTypeId { get; set; }
        public int? PropertiesTypeId { get; set; }
        public int? ImprovementsTypeId { get; set; }
        public string? AgentId { get; set; }
    }

    public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesQuery, Response<IList<PropertiesDTO>>>
    {
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IPropertiesImprovementsService _propertiesImprovementsService;

        public GetAllPropertiesQueryHandler(IPropertiesRepository propertiesRepository, IMapper mapper, IAccountService accountService, IPropertiesImprovementsService propertiesImprovementsService)
        {
            _propertiesRepository = propertiesRepository;
            _mapper = mapper;
            _accountService = accountService;
            _propertiesImprovementsService = propertiesImprovementsService;
        }

        public async Task<Response<IList<PropertiesDTO>>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            var filter = _mapper.Map<GetAllPropertiesParameter>(request);
            var propertiesList = await GetAllPropertiesDTOWithFilters(filter);
            if (propertiesList == null || propertiesList.Count == 0) throw new ApiException("No hay Productos", (int)HttpStatusCode.NoContent);

            return new Response<IList<PropertiesDTO>>(propertiesList);
        }

        public async Task<List<PropertiesDTO>> GetAllPropertiesDTOWithFilters(GetAllPropertiesParameter filter)
        {
            var list = await _propertiesRepository.GetAllWithIncludeAsync(new List<string> { "SaleType", "PropertiesTypes" });
            var dtoList = new List<PropertiesDTO>();

            if (filter.SalesTypeId > 0)
            {
                list = list.Where(x => x.SaleTypeId == filter.SalesTypeId).ToList();
            }

            if (filter.ImprovementsTypeId > 0 )
            {
            }

            if (filter.PropertiesTypeId > 0)
            {
                list = list.Where(x => x.PropertiesTypeId == filter.PropertiesTypeId).ToList();
            }

            if (filter.AgentId != null)
            {
                list = list.Where(x => x.AgentId == filter.AgentId).ToList();
            }

            foreach (var properties in list)
            {
                var agent = await _accountService.GetUserById(properties.AgentId);

                var dtoProperty = new PropertiesDTO
                {
                    Description = properties.Description,
                    BathroomQuantity = properties.BathroomQuantity,
                    RoomQuantity = properties.RoomQuantity,
                    LandSizeMeter = properties.LandSizeMeter,
                    Price = properties.Price,
                    Id = properties.Id,
                    Code = properties.Code,
                    PropertiesType = properties.PropertiesTypes.Name,
                    SaleType = properties.SaleType.Name,
                    Improvements = await _propertiesImprovementsService.GetImprovementsByPropertyId(properties.Id),
                    AgentId = properties.AgentId,
                    AgentName = $"{agent.FirstName} {agent.LastName}"
            };

                dtoList.Add(dtoProperty);
            }

            return dtoList;
        }
    }
}

