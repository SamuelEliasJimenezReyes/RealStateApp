
using System.ComponentModel.DataAnnotations;

namespace RealStateApp.Core.Application.ViewModels.AgentImages
{
    public class SaveAgentImagesVM
    {
        [Required(ErrorMessage = "Debe Introducir un agente")]
        public string AgentId { get; set; }
        public string? ImagePath { get; set; }
    }
}
