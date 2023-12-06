

using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealStateApp.Core.Application.Features.PropertiesTypes.Commands.CreatePropertiesTypes
{
    public class CreatePropertiesTypesCommand : IRequest<int>
    {
        public string Description { get; set; }
        public string Name { get; set; }
    }
    public class CreatePropertiesTypesCommandHandler : IRequestHandler<CreatePropertiesTypesCommand, int>
    {
        private readonly IPropertiesTypesRepository _propertiesTypesRepository;
        private readonly IMapper _mapper;
        public CreatePropertiesTypesCommandHandler(IPropertiesTypesRepository propertiesTypesRepository, IMapper mapper)
        {
            _propertiesTypesRepository = propertiesTypesRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreatePropertiesTypesCommand command, CancellationToken cancellationToken)
        {

            var add = new RealStateApp.Core.Domain.Entities.PropertiesTypes
            {
                Description = command.Description,
                Name = command.Name,
                
            };

            add = await _propertiesTypesRepository.AddAsync(add);

            return add.Id;

        }
    }


}
