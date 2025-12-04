using System.ComponentModel.DataAnnotations;

namespace Api_final.DTOs
{
    public class ServicioDto
    {
        [Required(ErrorMessage ="La descripción es obligatoria")]
        public string Descripcion_servicio { get; set; } = "";
    }
}
