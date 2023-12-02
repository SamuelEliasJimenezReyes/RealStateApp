

using RealStateApp.Core.Application.ViewModels.Improvements;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IImprovementsService : IGenericService<SaveImprovementsVM, ImprovementsVM, Improvements>
    {
    }
}
