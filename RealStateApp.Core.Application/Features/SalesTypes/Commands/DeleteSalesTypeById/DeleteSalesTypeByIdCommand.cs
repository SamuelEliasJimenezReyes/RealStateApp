
using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Interface.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RealStateApp.Core.Application.Features.SalesTypes.Commands.DeleteSalesTypeById
{
    public class DeleteSalesTypeByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

    }

    public class DeleteSalesTypeByIdCommandHandler : IRequestHandler<DeleteSalesTypeByIdCommand, int>
    {
        private readonly ISalesTypeRepository _salesTypeRepository;
        
        public DeleteSalesTypeByIdCommandHandler(ISalesTypeRepository salesTypeRepository)
        {
            _salesTypeRepository = salesTypeRepository;
        }

        public async Task<int> Handle(DeleteSalesTypeByIdCommand command, CancellationToken cancellationToken)
        {

            var type = await _salesTypeRepository.GetByIdAsync(command.Id);
            if (type == null) throw new Exception("SalesType not found");

            await _salesTypeRepository.DeleteAsync(type);

            return type.Id;
        }
    }
}
