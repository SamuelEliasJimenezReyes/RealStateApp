


using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Improvements;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using RealStateApp.Core.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace RealStateApp.Core.Application.Features.Improvements.Queries.GetAllImprovements
{
    public class GetAllImprovementsQuery : IRequest<Response<IList<ImprovementsDTO>>>
    {

    }

    public class GetAllImprovementsQueryHandler : IRequestHandler<GetAllImprovementsQuery, Response<IList<ImprovementsDTO>>>
    {
        private readonly IImprovementsRepository _repository;

        public GetAllImprovementsQueryHandler(IImprovementsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<IList<ImprovementsDTO>>> Handle(GetAllImprovementsQuery request, CancellationToken cancellationToken)
        {
            var list = await GetAll();

            if (list.Count == 0) throw new ApiException("no Content For Improvements", (int)HttpStatusCode.NoContent);

            return new Response<IList<ImprovementsDTO>>(list);

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
