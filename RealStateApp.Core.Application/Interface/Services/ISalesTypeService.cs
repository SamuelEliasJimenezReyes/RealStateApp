
using RealStateApp.Core.Domain.Entities;
using RealStateApp.Core.Application.ViewModels.SalesTypes;

namespace RealStateApp.Core.Application.Interface.Services
{
    public interface ISalesTypeService : IGenericService<SaveSalesTypesVM, SalesTypesVM, SalesTypes>
    {
    }
}
