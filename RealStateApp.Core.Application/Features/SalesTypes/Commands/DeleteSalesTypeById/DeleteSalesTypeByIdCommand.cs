
using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RealStateApp.Core.Application.Features.SalesTypes.Commands.DeleteSalesTypeById
{
    public class DeleteSalesTypeByIdCommand : IRequest<Response<int>>
    {
        [SwaggerParameter(Description = "Id Del tipo de venta a eliminar")]
        public int Id { get; set; }

    }

    public class DeleteSalesTypeByIdCommandHandler : IRequestHandler<DeleteSalesTypeByIdCommand, Response<int>>
    {
        private readonly ISalesTypeRepository _salesTypeRepository;
        
        public DeleteSalesTypeByIdCommandHandler(ISalesTypeRepository salesTypeRepository)
        {
            _salesTypeRepository = salesTypeRepository;
        }

        public async Task<Response<int>> Handle(DeleteSalesTypeByIdCommand command, CancellationToken cancellationToken)
        {

            var type = await _salesTypeRepository.GetByIdAsync(command.Id);
            if (type == null) throw new ApiException("SalesType not found", (int)HttpStatusCode.NotFound);

            await _salesTypeRepository.DeleteAsync(type);

            return new Response<int>(type.Id);
        }
    }
}
