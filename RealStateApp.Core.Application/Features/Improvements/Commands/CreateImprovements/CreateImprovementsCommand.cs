﻿


using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Improvements;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;

namespace RealStateApp.Core.Application.Features.Improvements.Commands.CreateImprovements
{
    public class CreateImprovementsCommand : IRequest<Response<int>>
    {
        [SwaggerParameter(Description = "crear Nombre de la mejora")]
        public string Name { get; set; }

        [SwaggerParameter(Description = "crear una descripcion de la mejora")]
        public string Description { get; set; }

    }

    public class CreateImprovementsCommandHandler : IRequestHandler<CreateImprovementsCommand, Response<int>>
    {
        private readonly IImprovementsRepository _repository;

        public CreateImprovementsCommandHandler(IImprovementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(CreateImprovementsCommand command, CancellationToken cancellationToken)
        {
            var add = new RealStateApp.Core.Domain.Entities.Improvements
            {
                Name = command.Name,
                Description = command.Description,
            };

            await _repository.AddAsync(add);

            return new Response<int>(add.Id);
        }
    }
}
