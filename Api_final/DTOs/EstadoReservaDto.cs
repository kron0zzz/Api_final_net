using System.ComponentModel.DataAnnotations;

namespace Api_final.DTOs
{
    public class EstadoReservaDto
    {
        [Required]
        public string Descripcion { get; set; } = "";
    }
}
