using Microsoft.AspNetCore.Mvc;

namespace Api_final.Models
{
    public class Reservas
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; } = DateTime.Now;


        public int IdServicio { get; set; }
        public Servicios? Servicios { get; set; }


        public int IdCliente { get; set; }
        public Clientes? Clientes { get; set; }
      

        public int Estado { get; set; }
        public EstadoReserva? EstadoReserva { get; set; }

    }
}
