

using System.ComponentModel.DataAnnotations;

namespace RealStateApp.Core.Application.ViewModels.ImagesProperties
{
    public class SaveImagesPropertiesVM
    {

        [Required(ErrorMessage = "Debe Introducir una propiedad")]
        public int PropertiesId { get; set; }

        [Required(ErrorMessage = "Debe Introducir una imagen")]
        public string ImageUrl { get; set; }
    }
}
