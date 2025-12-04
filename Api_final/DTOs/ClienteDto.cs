using System.ComponentModel.DataAnnotations;

namespace Api_final.DTOs
{
    public class ClienteDto
    {
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; } = "";


        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress]
        public string Email { get; set; } = "";


        [Required(ErrorMessage = "El número telefónico es obligatorio")]
        [Phone]
        public string Telefono { get; set; } = "";
    }
}
