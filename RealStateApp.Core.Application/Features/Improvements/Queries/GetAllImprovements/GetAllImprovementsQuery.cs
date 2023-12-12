


using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Improvements;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RealStateApp.Core.Application.Features.Improvements.Queries.GetAllImprovements
{
    public class GetAllImprovementsQuery : IRequest<IList<ImprovementsDTO>>
    {

    }

    public class GetAllImprovementsQueryHandler : IRequestHandler<GetAllImprovementsQuery, IList<ImprovementsDTO>>
    {
        private readonly IImprovementsRepository _repository;

        public GetAllImprovementsQueryHandler(IImprovementsRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<ImprovementsDTO>> Handle(GetAllImprovementsQuery request, CancellationToken cancellationToken)
        {
            var list = await GetAll();

            return list;

        }
         
        private async Task<List<ImprovementsDTO>> GetAll()
        {
            var list = await _repository.GetAllAsync();

            var map = list.Select(a => new ImprovementsDTO
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,

            }).ToList();

            return map;
        }
    }
}
