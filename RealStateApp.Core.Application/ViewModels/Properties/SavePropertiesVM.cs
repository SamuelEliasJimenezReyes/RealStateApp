using Microsoft.AspNetCore.Http;
using RealStateApp.Core.Application.ViewModels.Improvents;
using RealStateApp.Core.Application.ViewModels.PropertiesTypes;
using RealStateApp.Core.Application.ViewModels.SalesTypes;
using System.ComponentModel.DataAnnotations;

namespace RealStateApp.Core.Application.ViewModels.Properties
{
    public class SavePropertiesVM
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public double LandSizeMeter { get; set; }
        public int RoomQuantity { get; set; }
        public string Description { get; set; }
        public int BathroomQuantity { get; set; }
        public string AgentId { get; set; }
        public int PropertiesTypeId { get; set; }

        public int SaleTypeId { get; set; }
        public List<string>? ImagePath { get; set; } = null!;

        [DataType(DataType.ImageUrl)]
        public List<IFormFile>? File { get; set; } = null!;
        public List<int> PropertiesImproventsId { get; set; }

        public List<string> ImagesProperties { get; set; }

        //Listas para usar en los Select 
        public List<ImproventsVM> improvents { get; set; }
        public List<SalesTypesVM> SalesTypes { get; set; }
        public List<PropertiesTypesVM> PropertiesTypes { get; set; }
    }
}