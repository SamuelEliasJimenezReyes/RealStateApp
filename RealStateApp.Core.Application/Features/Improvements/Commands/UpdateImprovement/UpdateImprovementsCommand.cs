

using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Improvements;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealStateApp.Core.Application.Features.Improvements.Commands.UpdateImprovement
{
    public class UpdateImprovementsCommand : IRequest<ImprovementsUpdateResponse>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }

    public class UpdateImprovementsCommandHandler : IRequestHandler<UpdateImprovementsCommand, ImprovementsUpdateResponse>
    {
        private readonly IImprovementsRepository _repository;

        public UpdateImprovementsCommandHandler(IImprovementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImprovementsUpdateResponse> Handle(UpdateImprovementsCommand command, CancellationToken cancellationToken)
        {
            var type = await _repository.GetByIdAsync(command.Id);


            if (type == null) throw new Exception("PropertiesType not found");

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

            return response;
        }
    }
}
