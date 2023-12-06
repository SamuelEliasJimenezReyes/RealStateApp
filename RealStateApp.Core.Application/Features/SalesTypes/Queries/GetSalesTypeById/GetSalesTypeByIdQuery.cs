
using AutoMapper;
using MediatR;
using RealStateApp.Core.Application.Dtos.Api.SalesTypes;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealStateApp.Core.Application.Features.SalesTypes.Queries.GetSalesTypeById
{

    public class GetSalesTypeByIdQuery : IRequest<SalesTypesDTO>
    {
        public int Id { get; set; }
    }

    public class GetSalesTypeByIdQueryHandler : IRequestHandler<GetSalesTypeByIdQuery, SalesTypesDTO>
    {
        private readonly ISalesTypeRepository _salesTypeRepository;
        private readonly IMapper _mapper;
        public GetSalesTypeByIdQueryHandler(ISalesTypeRepository salesTypeRepository, IMapper mapper)
        {
            _salesTypeRepository = salesTypeRepository;
            _mapper = mapper;
        }
        public async Task<SalesTypesDTO> Handle(GetSalesTypeByIdQuery request, CancellationToken cancell)
        {
            var type = await GetById(request.Id);
            if (type == null) throw new Exception("SalesType not found");
            return type;
        }

        private async Task<SalesTypesDTO> GetById(int id)
        {
            var type = await _salesTypeRepository.GetByIdAsync(id);

            SalesTypesDTO dto = new SalesTypesDTO
            {
                Id = type.Id,
                Description = type.Description,
                Name = type.Name,

            };

            return dto;
        }


    }
}
