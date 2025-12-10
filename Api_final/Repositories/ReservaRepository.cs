using Api_final.Data;
using Api_final.Interfaces;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Api_final.Models;

namespace Api_final.Repositories
{
    public class ReservaRepository : IReservaRepository 
    {
        private readonly ApiContext _context;
        public ReservaRepository(ApiContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Reservas>> GetAllAsync() =>
            await _context.Reservas.ToListAsync();

        public async Task<Reservas?> GetByIdAsync(int id) =>
        await _context.Reservas.FindAsync(id);


        public async Task<Reservas> AddAsync(Reservas reservas)
        {
            _context.Reservas.Add(reservas);
            await _context.SaveChangesAsync();
            return reservas;
        }


        public async Task<Reservas?> UpdateAsync(int id, Reservas reservas)
        {
            var existing = await _context.Reservas.FindAsync(id);
            if (existing == null) return null;

            existing.IdServicio = reservas.IdServicio;
            existing.IdCliente = reservas.IdCliente; 
            existing.Estado = reservas.Estado;


            await _context.SaveChangesAsync();
            return existing;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var re = await _context.Reservas.FindAsync(id);
            if (re == null) return false;


            _context.Reservas.Remove(re);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
