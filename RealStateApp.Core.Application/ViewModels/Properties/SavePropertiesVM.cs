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

        [Required(ErrorMessage = "Debe Introducir un precio")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Debe Introducir una longitud")]
        public double LandSizeMeter { get; set; }

        [Required(ErrorMessage = "Debe Introducir cantidad de habitaciones")]
        public int RoomQuantity { get; set; }
        [Required(ErrorMessage = "Debe Introducir una Descripción")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Debe Introducir la cantidad de baños")]
        public int BathroomQuantity { get; set; }
        [Required(ErrorMessage = "Debe Introducir un Agente")]
        public string AgentId { get; set; }
        [Required(ErrorMessage = "Debe Introducir un tipo de propiedad")]
        public int PropertiesTypeId { get; set; }
        [Required(ErrorMessage = "Debe Introducir un tipo de venta")]
        public int SaleTypeId { get; set; }

        [DataType(DataType.ImageUrl)]
        public List<IFormFile>? File { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir una mejora")]
        public List<int> PropertiesImprovementsId { get; set; }

        [Required(ErrorMessage = "Debe Introducir una imagen")]
        public List<string> ImagesProperties { get; set; } = new();

        //Listas para usar en los Select 
        public List<ImprovementsVM> Improvements { get; set; }
        public List<SalesTypesVM> SalesTypes { get; set; }
        public List<PropertiesTypesVM> PropertiesTypes { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError { get; set; }

    }

}