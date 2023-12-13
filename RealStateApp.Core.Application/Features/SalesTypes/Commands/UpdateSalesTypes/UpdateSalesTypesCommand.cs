
using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Exceptions;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using System.Net;

namespace RealStateApp.Core.Application.Features.SalesTypes.Commands.UpdateSalesTypes
{
    public class UpdateSalesTypesCommand : IRequest<Response<SalesTypesUpdateResponse>>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }

    public class UpdateSalesTypesCommandHandler : IRequestHandler<UpdateSalesTypesCommand, Response<SalesTypesUpdateResponse>>
    {
        private readonly ISalesTypeRepository _salesTypeRepository;
        private readonly IMapper _mapper;
        public UpdateSalesTypesCommandHandler(ISalesTypeRepository salesTypeRepository, IMapper mapper)
        {
            _salesTypeRepository = salesTypeRepository;
            _mapper = mapper;
        }
        public async Task<Response<SalesTypesUpdateResponse>> Handle(UpdateSalesTypesCommand command, CancellationToken cancellationToken)
        {
            var type = await _salesTypeRepository.GetByIdAsync(command.Id);

            
                if (type == null) throw new ApiException("SalesType not found", (int)HttpStatusCode.NotFound);

            type = new Domain.Entities.SalesTypes
            {
                Id = command.Id,
                Description = command.Description,
                Name = command.Name,
            };

            await _salesTypeRepository.UpdateAsync(type, type.Id);

            var response = new SalesTypesUpdateResponse
            {
                Id = command.Id,
                Description = command.Description,
                Name = command.Name,
            };

            return new Response<SalesTypesUpdateResponse>(response);
            
        }
    }
}
