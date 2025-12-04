using Api_final.Data;
using Api_final.Interfaces;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Api_final.Models;

namespace Api_final.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApiContext _context;
        public ClienteRepository(ApiContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Clientes>> GetAllAsync() =>
            await _context.Clientes.ToListAsync();

        public async Task<Clientes?> GetByIdAsync(int id) =>
        await _context.Clientes.FindAsync(id);


        public async Task<Clientes> AddAsync(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();
            return clientes;
        }


        public async Task<Clientes?> UpdateAsync(int id, Clientes clientes)
        {
            var existing = await _context.Clientes.FindAsync(id);
            if (existing == null) return null;


            existing.Nombre = clientes.Nombre;
            existing.Email = clientes.Email;
            existing.Telefono = clientes.Telefono;


            await _context.SaveChangesAsync();
            return existing;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var cl = await _context.Clientes.FindAsync(id);
            if (cl == null) return false;


            _context.Clientes.Remove(cl);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
