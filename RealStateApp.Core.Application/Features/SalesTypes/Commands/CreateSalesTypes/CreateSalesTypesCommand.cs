
using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;

namespace RealStateApp.Core.Application.Features.SalesTypes.Commands.CreateSalesTypes
{
    public class CreateSalesTypesCommand : IRequest<Response<int>>
    {
        [SwaggerParameter(Description = "Crear descripcion para tipo de ventas")]
        public string Description { get; set; }

        [SwaggerParameter(Description = "Crear nombre para tipo de ventas")]
        public string Name { get; set; }

    }

    public class CreateSalesTypesCommandHandler : IRequestHandler<CreateSalesTypesCommand, Response<int>>
    {
        private readonly ISalesTypeRepository _salesTypeRepository;
        private readonly IMapper _mapper;
        public CreateSalesTypesCommandHandler(ISalesTypeRepository salesTypeRepository, IMapper mapper)
        {
            _salesTypeRepository = salesTypeRepository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateSalesTypesCommand command, CancellationToken cancellationToken)
        {

            var add = new RealStateApp.Core.Domain.Entities.SalesTypes
            {
                Description = command.Description,
                Name = command.Name,

            };

            add = await _salesTypeRepository.AddAsync(add);

            return new Response<int>(add.Id);

        }
    }


}

