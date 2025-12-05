using Api_final.Data;
using Api_final.Interfaces;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Api_final.Models;

namespace Api_final.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly ApiContext _context;
        public ServicioRepository(ApiContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Servicios>> GetAllAsync() =>
            await _context.Servicios.ToListAsync();

        public async Task<Servicios?> GetByIdAsync(int id) =>
        await _context.Servicios.FindAsync(id);


        public async Task<Servicios> AddAsync(Servicios servicios)
        {
            _context.Servicios.Add(servicios);
            await _context.SaveChangesAsync();
            return servicios;
        }


        public async Task<Servicios?> UpdateAsync(int id, Servicios servicios)
        {
            var existing = await _context.Servicios.FindAsync(id);
            if (existing == null) return null;


            existing.Descripcion_servicio = servicios.Descripcion_servicio;


            await _context.SaveChangesAsync();
            return existing;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var se = await _context.Servicios.FindAsync(id);
            if (se == null) return false;


            _context.Servicios.Remove(se);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}