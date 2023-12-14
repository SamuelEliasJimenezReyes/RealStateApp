

using System.ComponentModel.DataAnnotations;

namespace RealStateApp.Core.Application.ViewModels.Improvements
{
    public class SaveImprovementsVM
    {

        [Required(ErrorMessage = "Debe Introducir una descripcion")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Debe Introducir un nombre")]
        public string Name { get; set; }
    }
}
