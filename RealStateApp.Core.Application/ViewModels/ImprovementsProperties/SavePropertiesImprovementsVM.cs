

using System.ComponentModel.DataAnnotations;

namespace RealStateApp.Core.Application.ViewModels.ImprovementsProperties
{
    public class SavePropertiesImprovementsVM
    {
        [Required(ErrorMessage = "Debe Introducir una propiedad")]
        public int PropertiesId { get; set; }

        [Required(ErrorMessage = "Debe Introducir una mejora")]
        public int ImprovementId { get; set; }
    }
}
