

using MediatR;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealStateApp.Core.Application.Features.PropertiesTypes.Commands.DeletePropertiesTypeById
{
    public class DeletePropertiesTypesByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

    }

   

    public class DeletePropertiesTypesByIdCommandHandler : IRequestHandler<DeletePropertiesTypesByIdCommand, int>
    {
        private readonly IPropertiesTypesRepository _propertiesTypesRepository;

        public DeletePropertiesTypesByIdCommandHandler(IPropertiesTypesRepository propertiesTypesRepository)
        {
            _propertiesTypesRepository = propertiesTypesRepository;
        }

        public async Task<int> Handle(DeletePropertiesTypesByIdCommand command, CancellationToken cancellationToken)
        {

            var type = await _propertiesTypesRepository.GetByIdAsync(command.Id);
            if (type == null) throw new Exception("SalesType not found");

            await _propertiesTypesRepository.DeleteAsync(type);

            return type.Id;
        }
    }
}
