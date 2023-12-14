

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RealStateApp.Core.Application.ViewModels.Agents
{
    public class UpdateAgentVM
    {
        [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Debe colocar el apellido del usuario")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Debe ingresar un número de Télefono")]
        public string Phone { get; set; }
        public string? ImagePath { get; set; } = null!;

        [DataType(DataType.ImageUrl)]
        public IFormFile? File { get; set; } = null!;
        public string? agentId { get; set; }
        public bool HasError { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
