using Api_final.Models;

namespace Api_final.Interfaces
{
    public interface IReservaRepository
    {


        Task<IEnumerable<Reservas>> GetAllAsync();
        Task<Reservas?> GetByIdAsync(int id);
        Task<Reservas> AddAsync(Reservas reservas);
        Task<Reservas?> UpdateAsync(int id, Reservas reservas);
        Task<bool> DeleteAsync(int id);

    }
}
