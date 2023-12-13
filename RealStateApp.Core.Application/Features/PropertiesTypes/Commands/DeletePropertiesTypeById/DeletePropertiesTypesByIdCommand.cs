

using MediatR;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using System.Net;

namespace RealStateApp.Core.Application.Features.PropertiesTypes.Commands.DeletePropertiesTypeById
{
    public class DeletePropertiesTypesByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

    }

   

    public class DeletePropertiesTypesByIdCommandHandler : IRequestHandler<DeletePropertiesTypesByIdCommand, Response<int>>
    {
        private readonly IPropertiesTypesRepository _propertiesTypesRepository;

        public DeletePropertiesTypesByIdCommandHandler(IPropertiesTypesRepository propertiesTypesRepository)
        {
            _propertiesTypesRepository = propertiesTypesRepository;
        }

        public async Task<Response<int>> Handle(DeletePropertiesTypesByIdCommand command, CancellationToken cancellationToken)
        {

            var type = await _propertiesTypesRepository.GetByIdAsync(command.Id);
            if (type == null) throw new ApiException("SalesType not found", (int)HttpStatusCode.NotFound);

            await _propertiesTypesRepository.DeleteAsync(type);

            return new Response<int>(type.Id);
        }
    }
}
