

using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Features.SalesTypes.Commands.UpdateSalesTypes;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealStateApp.Core.Application.Features.PropertiesTypes.Commands.UpdatePropertiesTypes
{
        public class UpdatePropertiesTypesCommand : IRequest<PropertiesTypesUpdateResponse>
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public string Name { get; set; }
        }

        public class UpdatePropertiesTypesCommandHandler : IRequestHandler<UpdatePropertiesTypesCommand, PropertiesTypesUpdateResponse>
        {
            private readonly IPropertiesTypesRepository _propertiesTypesRepository;
            private readonly IMapper _mapper;
            public UpdatePropertiesTypesCommandHandler(IPropertiesTypesRepository propertiesTypesRepository, IMapper mapper)
            {
                _propertiesTypesRepository = propertiesTypesRepository;
                _mapper = mapper;
            }
            public async Task<PropertiesTypesUpdateResponse> Handle(UpdatePropertiesTypesCommand command, CancellationToken cancellationToken)
            {
                var type = await _propertiesTypesRepository.GetByIdAsync(command.Id);


                if (type == null) throw new Exception("PropertiesType not found");

                type = new Domain.Entities.PropertiesTypes
                {
                    Id = command.Id,
                    Description = command.Description,
                    Name = command.Name,
                };

                await _propertiesTypesRepository.UpdateAsync(type, type.Id);

                var response = new PropertiesTypesUpdateResponse
                {
                    Id = command.Id,
                    Description = command.Description,
                    Name = command.Name,
                };

                return response;

            }
        }
    }

