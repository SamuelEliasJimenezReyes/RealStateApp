


using MediatR;
using RealStateApp.Core.Application.Dtos.Api.Improvements;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealStateApp.Core.Application.Features.Improvements.Commands.CreateImprovements
{
    public class CreateImprovementsCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

    }

    public class CreateImprovementsCommandHandler : IRequestHandler<CreateImprovementsCommand, int>
    {
        private readonly IImprovementsRepository _repository;

        public CreateImprovementsCommandHandler(IImprovementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateImprovementsCommand command, CancellationToken cancellationToken)
        {
            var add = new RealStateApp.Core.Domain.Entities.Improvements
            {
                Name = command.Name,
                Description = command.Description,
            };

            await _repository.AddAsync(add);

            return add.Id;
        }
    }
}
