
using MediatR;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealStateApp.Core.Application.Features.Improvements.Commands.DeleteImprovementById
{
    public class DeleteImprovementsByIdCommand : IRequest<int>
    {
        public int Id { get; set; } 
    }

    public class DeleteImprovementsByIdCommandHandler : IRequestHandler<DeleteImprovementsByIdCommand, int>
    {
        private readonly IImprovementsRepository _repository;

        public DeleteImprovementsByIdCommandHandler(IImprovementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteImprovementsByIdCommand command, CancellationToken cancellationToken)
        {
            var get = await _repository.GetByIdAsync(command.Id);

            await _repository.DeleteAsync(get);

            return get.Id;
        }

       
    }
}
