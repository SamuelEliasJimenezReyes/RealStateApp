

using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Improvements;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealStateApp.Core.Application.Features.Improvements.Queries.GetImprovementById
{
    public class GetImprovementByIdQuery : IRequest<ImprovementsDTO>
    {
        public int Id { get; set; }

    }
    
    public class GetImprovementByIdQueryHandler : IRequestHandler<GetImprovementByIdQuery, ImprovementsDTO>
    {
       private readonly IImprovementsRepository _repository;

        public GetImprovementByIdQueryHandler(IImprovementsRepository repository)
        {           
            _repository = repository;
        }

        public async Task<ImprovementsDTO> Handle(GetImprovementByIdQuery request, CancellationToken cancellationToken)
        {
            var get = await GetById(request.Id);

            if (get == null)
            {
                throw new Exception("Improvement no found");
            }

            return get;
        }

        private async Task<ImprovementsDTO> GetById(int id)
        {
           var get = await _repository.GetByIdAsync(id);

            ImprovementsDTO dto = new ImprovementsDTO { 
            
            Id = id,
            Name = get.Name,
            Description = get.Description,
                                 
            };

            return dto;

        }
    }
}
