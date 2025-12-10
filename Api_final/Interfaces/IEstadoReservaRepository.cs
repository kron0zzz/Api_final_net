using Api_final.Models;

namespace Api_final.Interfaces
{
    public interface IEstadoReservaRepository
    {
        Task<IEnumerable<EstadoReserva>> GetAllAsync();
        Task<EstadoReserva> AddAsync(EstadoReserva estadoReserva);
        Task<EstadoReserva?> UpdateAsync(int id, EstadoReserva estadoReserva);
        Task<bool> DeleteAsync(int id);
    }
}