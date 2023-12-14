
using MediatR;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RealStateApp.Core.Application.Features.Improvements.Commands.DeleteImprovementById
{
    public class DeleteImprovementsByIdCommand : IRequest<Response<int>>
    {
        [SwaggerParameter(Description = "Id De la mejora a eliminar")]
        public int Id { get; set; } 
    }

    public class DeleteImprovementsByIdCommandHandler : IRequestHandler<DeleteImprovementsByIdCommand, Response<int>>
    {
        private readonly IImprovementsRepository _repository;

        public DeleteImprovementsByIdCommandHandler(IImprovementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteImprovementsByIdCommand command, CancellationToken cancellationToken)
        {
            var get = await _repository.GetByIdAsync(command.Id);

            if (get == null) throw new ApiException("Improvements not found", (int)HttpStatusCode.NotFound);

            await _repository.DeleteAsync(get);

            return new Response<int>(get.Id);
        }

       
    }
}
