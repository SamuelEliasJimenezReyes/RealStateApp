

using RealStateApp.Core.Application.ViewModels.Improvents;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IImproventService : IGenericService<SaveImproventsVM, ImproventsVM, Improvements>
    {
    }
}
