

using AutoMapper;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Improvements;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Services
{
    public class ImprovementsServices : GenericService<SaveImprovementsVM, ImprovementsVM, Improvements>, IImprovementsService
    {
        private readonly IImprovementsRepository _improvementsRepository;
        private readonly IMapper _mapper;

        public ImprovementsServices(IImprovementsRepository improvementsRepository, IMapper mapper) : base (improvementsRepository, mapper)
        {
            _improvementsRepository = improvementsRepository;
            _mapper = mapper;
        }
    }
}
