using System.ComponentModel.DataAnnotations;

namespace Api_final.DTOs
{
    public class ReservaDto
    {
        [Required]
        public DateTime FechaReserva { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int Estado { get; set; }
    }
}
