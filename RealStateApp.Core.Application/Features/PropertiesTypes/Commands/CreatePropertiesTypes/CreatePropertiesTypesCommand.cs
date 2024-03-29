﻿

using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;

namespace RealStateApp.Core.Application.Features.PropertiesTypes.Commands.CreatePropertiesTypes
{
    public class CreatePropertiesTypesCommand : IRequest<Response<int>>
    {
        [SwaggerParameter(Description = "crear Descripcion del tipo de propiedad")]
        public string Description { get; set; }

        [SwaggerParameter(Description = "crear Nombre del tipo de propiedad")]
        public string Name { get; set; }
    }
    public class CreatePropertiesTypesCommandHandler : IRequestHandler<CreatePropertiesTypesCommand, Response<int>>
    {
        private readonly IPropertiesTypesRepository _propertiesTypesRepository;
        private readonly IMapper _mapper;
        public CreatePropertiesTypesCommandHandler(IPropertiesTypesRepository propertiesTypesRepository, IMapper mapper)
        {
            _propertiesTypesRepository = propertiesTypesRepository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreatePropertiesTypesCommand command, CancellationToken cancellationToken)
        {

            var add = new RealStateApp.Core.Domain.Entities.PropertiesTypes
            {
                Description = command.Description,
                Name = command.Name,
                
            };

            add = await _propertiesTypesRepository.AddAsync(add);

            return new Response<int>(add.Id);

        }
    }


}
