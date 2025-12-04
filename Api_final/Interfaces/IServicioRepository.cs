using Api_final.Models;

namespace Api_final.Interfaces
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicios>> GetAllAsync();
        Task<Servicios> AddAsync(Servicios servicios);
        Task<Servicios?> UpdateAsync(int id, Servicios servicios);
        Task<bool> DeleteAsync(int id);
    }
}
