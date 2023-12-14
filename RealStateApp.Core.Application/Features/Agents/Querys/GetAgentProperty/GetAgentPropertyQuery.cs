
using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Properties;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.Wrappers;
using System.Net;

namespace RealStateApp.Core.Application.Features.Agents.Querys.GetAgentProperty
{
    public class GetAgentPropertyQuery : IRequest<Response<IList<PropertiesDTO>>>
    {
        public string Id { get; set; }

    }

    public class GetAgentPropertyQueryHandler : IRequestHandler<GetAgentPropertyQuery, Response<IList<PropertiesDTO>>>
    {
        private readonly IAccountService _accountService;
        private readonly IPropertiesImprovementsService _propertiesImprovementsService;
        private readonly IPropertiesRepository _propertiesRepository;

        public GetAgentPropertyQueryHandler(IAccountService accountService, IPropertiesRepository propertiesRepository, IPropertiesImprovementsService propertiesImprovementsService)
        {
            _accountService = accountService;
            _propertiesRepository = propertiesRepository;
            _propertiesImprovementsService = propertiesImprovementsService;
        }
        public async Task<Response<IList<PropertiesDTO>>> Handle(GetAgentPropertyQuery request, CancellationToken cancellationToken)
        {
            var get = await GetAgentPropertiesById(request.Id);
            if (get == null) throw new ApiException("Agent doest has properties", (int)HttpStatusCode.NotFound);

            return new Response<IList<PropertiesDTO>>(get);
        }

        private async Task<List<PropertiesDTO>> GetAgentPropertiesById(string id)
        {

            var list = await _propertiesRepository.GetAllWithIncludeAsync(new List<string> { "SaleTypes", "PropertiesTypes" });
            var dtoList = new List<PropertiesDTO>();

            foreach (var properties in list.Where(a => a.AgentId == id))
            {
                var agent = await _accountService.GetUserById(id);

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

                dtoList.Add(dtoProperty);
            }

            return dtoList;
        }
    }
}
