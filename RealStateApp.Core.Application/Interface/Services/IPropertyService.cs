

using AutoMapper;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.ViewModels.Properties;
using RealStateApp.Core.Domain.Entities;

namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IPropertyService : IGenericService<SavePropertiesVM, PropertiesVM, Properties>
    {
        
    }
}
