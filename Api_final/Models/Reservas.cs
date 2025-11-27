using Microsoft.AspNetCore.Mvc;

namespace Api_final.Models
{
    public class Reservas
    {
        public int Id { get; set; }
        public string FechaReserva { get; set; } = "";
        public int IdServicio { get; set; }
        public int IdCliente { get; set; }
      

        public int Estado { get; set; }
        public EstadoReserva? EstadoReserva { get; set; }

    }
}
