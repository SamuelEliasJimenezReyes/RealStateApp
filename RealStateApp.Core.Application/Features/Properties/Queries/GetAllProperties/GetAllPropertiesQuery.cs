

using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Properties;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;

namespace RealStateApp.Core.Application.Features.Properties.Queries.GetAllProperties
{
    public class GetAllPropertiesQuery : IRequest<IList<PropertiesDTO>>
    {
        public int? SalesTypeId { get; set; }
        public int? PropertiesTypeId { get; set; }
        public int? ImprovementsTypeId { get; set; }
        public string? AgentId { get; set; }
    }

    public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesQuery, IList<PropertiesDTO>>
    {
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IMapper mapper;
        private readonly IAccountService _accountService;
        private readonly IPropertiesImprovementsService _propertiesImprovementsService;

        public GetAllPropertiesQueryHandler(IPropertiesRepository propertiesRepository, IMapper mapper, IAccountService accountService, IPropertiesImprovementsService propertiesImprovementsService)
        {
            _propertiesRepository = propertiesRepository;
            this.mapper = mapper;
            _accountService = accountService;
            _propertiesImprovementsService = propertiesImprovementsService;
        }

        public async Task<IList<PropertiesDTO>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            return null;
        }

        public async Task<List<PropertiesDTO>> GetAllPropertiesDTOWithFilters(GetAllPropertiesParameter fitler)
        {
            var list = await _propertiesRepository.GetAllWithIncludeAsync(new List<string> { "SaleType", "PropertiesTypes" });
            var dtoList = new List<PropertiesDTO>();

            foreach(var properties in list)
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
                    AgentName = $"{agent.FirstName} + ' ' + {agent.LastName}"
            };

                dtoList.Add(dtoProperty);
            }
            return dtoList;
        }
    }
}

