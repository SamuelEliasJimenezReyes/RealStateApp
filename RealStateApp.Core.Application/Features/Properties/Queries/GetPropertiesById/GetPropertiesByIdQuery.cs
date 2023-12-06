
using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Properties;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;

namespace RealStateApp.Core.Application.Features.Properties.Queries.GetPropertiesById
{
    public class GetPropertiesByIdQuery : IRequest<PropertiesDTO>
    {
        public int Id { get; set; }
    }

    public class GetPropertiesByIdQueryHandler : IRequestHandler<GetPropertiesByIdQuery, PropertiesDTO>
    {
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IPropertiesImprovementsService _propertiesImprovementsService;
        private readonly IAccountService _accountService;

        public GetPropertiesByIdQueryHandler(IPropertiesRepository propertiesRepository, 
            IPropertiesImprovementsService propertiesImprovementsService, 
            IAccountService accountService)
        {
            _propertiesRepository = propertiesRepository;
            _propertiesImprovementsService = propertiesImprovementsService;
            _accountService = accountService;
        }

        public async Task<PropertiesDTO> Handle(GetPropertiesByIdQuery request, CancellationToken cancellationToken)
        {
            var property = await GetPropertyById(request.Id);
            if (property == null) throw new Exception("Property Not Found");
            return property;
        }

        protected async Task<PropertiesDTO> GetPropertyById(int id)
        {
            var list = await _propertiesRepository.GetAllWithIncludeAsync(new List<string> { "SaleType", "PropertiesTypes" });

            var properties = list.FirstOrDefault(x => x.Id == id);

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
                    AgentName = $"{agent.FirstName} + + {agent.LastName}"
                };

            return dtoProperty;
        }
    }
}
