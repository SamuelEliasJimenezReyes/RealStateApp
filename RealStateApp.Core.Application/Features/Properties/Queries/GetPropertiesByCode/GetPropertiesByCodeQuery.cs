

using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Properties;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Features.Properties.Queries.GetPropertiesById;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RealStateApp.Core.Application.Features.Properties.Queries.GetPropertiesByCode
{
    public class GetPropertiesByCodeQuery: IRequest<Response<PropertiesDTO>>
    {
        [SwaggerParameter(Description = "Codigo de la propiedad a obtener")]
        public string Code { get; set; }
    }

    public class GetPropertiesByCodeQueryHandler : IRequestHandler<GetPropertiesByCodeQuery, Response<PropertiesDTO>>
    {
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IPropertiesImprovementsService _propertiesImprovementsService;
        private readonly IAccountService _accountService;

        public GetPropertiesByCodeQueryHandler(IPropertiesRepository propertiesRepository, 
            IPropertiesImprovementsService propertiesImprovementsService, 
            IAccountService accountService)
        {
            _propertiesRepository = propertiesRepository;
            _propertiesImprovementsService = propertiesImprovementsService;
            _accountService = accountService;
        }


        public async Task<Response<PropertiesDTO>> Handle(GetPropertiesByCodeQuery request, CancellationToken cancellationToken)
        {
            var property = await GetPropertyByCode(request.Code);
            if (property == null) throw new ApiException("Property Not Found", (int)HttpStatusCode.NotFound);
            return new Response<PropertiesDTO>(property);
        }

        protected async Task<PropertiesDTO> GetPropertyByCode(string code)
        {
            var list = await _propertiesRepository.GetAllWithIncludeAsync(new List<string> { "SaleType", "PropertiesTypes" });

            var properties = list.FirstOrDefault(x => x.Code == code);

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

            return dtoProperty;
        }
    }
}

