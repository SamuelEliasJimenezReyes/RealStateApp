using RealStateApp.Core.Application.ViewModels.AgentImages;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IAgentImagesService : IGenericService<SaveAgentImagesVM, AgentImagesVM, AgentImages>
    {
        Task<string> GetImagesByAgentId(string agentId);
    }
}
