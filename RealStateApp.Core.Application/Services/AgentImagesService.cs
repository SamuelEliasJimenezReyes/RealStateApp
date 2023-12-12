

using AutoMapper;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.AgentImages;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Services
{
    public class AgentImagesService : GenericService<SaveAgentImagesVM, AgentImagesVM, AgentImages>, IAgentImagesService
    {
        private readonly IAgentImagesRepository _agentImagesRepository;
        private readonly IMapper _mapper;

        public AgentImagesService(IAgentImagesRepository agentImagesRepository,
            IMapper mapper) : base(agentImagesRepository, mapper) 
        {
            _agentImagesRepository = agentImagesRepository;
            _mapper = mapper;
        }

        public async Task<string> GetImagesByAgentId(string agentId)
        {
            var list = await GetAllViewModel();

            return list.Where(x => x.AgentId == agentId).Select(x => x.ImagePath).FirstOrDefault();
        }
    }
}
