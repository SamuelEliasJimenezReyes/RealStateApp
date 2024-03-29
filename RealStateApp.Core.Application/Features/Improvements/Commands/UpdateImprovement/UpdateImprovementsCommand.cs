﻿

using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Improvements;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RealStateApp.Core.Application.Features.Improvements.Commands.UpdateImprovement
{
    public class UpdateImprovementsCommand : IRequest<Response<ImprovementsUpdateResponse>>
    {
        [SwaggerParameter(Description = "Id De la mejora a modificar")]
        public int Id { get; set; }

        [SwaggerParameter(Description = "una nueva Descripcion de la mejora")]
        public string Description { get; set; }

        [SwaggerParameter(Description = "nuevo Nombre de la mejora")]
        public string Name { get; set; }
    }

    public class UpdateImprovementsCommandHandler : IRequestHandler<UpdateImprovementsCommand, Response<ImprovementsUpdateResponse>>
    {
        private readonly IImprovementsRepository _repository;

        public UpdateImprovementsCommandHandler(IImprovementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<ImprovementsUpdateResponse>> Handle(UpdateImprovementsCommand command, CancellationToken cancellationToken)
        {
            var type = await _repository.GetByIdAsync(command.Id);


            if (type == null) throw new ApiException("Improvements not found", (int)HttpStatusCode.NotFound);

            type = new Domain.Entities.Improvements
            {
                Id = command.Id,
                Description = command.Description,
                Name = command.Name,
            };

            await _repository.UpdateAsync(type, type.Id);

            var response = new ImprovementsUpdateResponse
            {
                Id = command.Id,
                Description = command.Description,
                Name = command.Name,
            };

            return new Response<ImprovementsUpdateResponse>(response);
        }
    }
}
