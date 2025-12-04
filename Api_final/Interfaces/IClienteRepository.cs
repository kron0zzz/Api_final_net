using Api_final.Models;

namespace Api_final.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes?> GetByIdAsync(int id);
        Task<Clientes> AddAsync(Clientes clientes);
        Task<Clientes?> UpdateAsync(int id, Clientes clientes);
        Task<bool> DeleteAsync(int id);
    }
}
