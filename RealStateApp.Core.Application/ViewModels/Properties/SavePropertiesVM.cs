using Microsoft.AspNetCore.Http;
using RealStateApp.Core.Application.ViewModels.Improvements;
using RealStateApp.Core.Application.ViewModels.PropertiesTypes;
using RealStateApp.Core.Application.ViewModels.SalesTypes;
using System.ComponentModel.DataAnnotations;

namespace RealStateApp.Core.Application.ViewModels.Properties
{
    public class SavePropertiesVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public double LandSizeMeter { get; set; }
        public int RoomQuantity { get; set; }
        public string Description { get; set; }
        public int BathroomQuantity { get; set; }
        public string AgentId { get; set; }
        public int PropertiesTypeId { get; set; }

        public int SaleTypeId { get; set; }

        [DataType(DataType.ImageUrl)]
        public List<IFormFile>? File { get; set; } = null!;
        public List<int> PropertiesImprovementsId { get; set; }

        public List<string> ImagesProperties { get; set; } = new();

        //Listas para usar en los Select 
        public List<ImprovementsVM> Improvements { get; set; }
        public List<SalesTypesVM> SalesTypes { get; set; }
        public List<PropertiesTypesVM> PropertiesTypes { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError { get; set; }

    }

}