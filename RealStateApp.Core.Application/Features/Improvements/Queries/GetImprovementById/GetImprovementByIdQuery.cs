

using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Improvements;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RealStateApp.Core.Application.Features.Improvements.Queries.GetImprovementById
{
    public class GetImprovementByIdQuery : IRequest<Response<ImprovementsDTO>>
    {
        [SwaggerParameter(Description = "Id De La mejora a obtener")]
        public int Id { get; set; }

    }
    
    public class GetImprovementByIdQueryHandler : IRequestHandler<GetImprovementByIdQuery, Response<ImprovementsDTO>>
    {
       private readonly IImprovementsRepository _repository;

        public GetImprovementByIdQueryHandler(IImprovementsRepository repository)
        {           
            _repository = repository;
        }

        public async Task<Response<ImprovementsDTO>> Handle(GetImprovementByIdQuery request, CancellationToken cancellationToken)
        {
            var get = await GetById(request.Id);

            if (get == null) throw new ApiException("Improvements not found", (int)HttpStatusCode.NotFound);

            return new Response<ImprovementsDTO>(get);
        }

        private async Task<ImprovementsDTO> GetById(int id)
        {
           var get = await _repository.GetByIdAsync(id);

            if (get == null) throw new ApiException("Improvements not found", (int)HttpStatusCode.NotFound);

            ImprovementsDTO dto = new ImprovementsDTO { 
            
            Id = id,
            Name = get.Name,
            Description = get.Description,
                                 
            };

            return dto;

        }
    }
}
