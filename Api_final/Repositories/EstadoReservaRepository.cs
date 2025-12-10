using Api_final.Data;
using Api_final.Interfaces;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Api_final.Models;

namespace Api_final.Repositories
{
    public class EstadoReservaRepository : IEstadoReservaRepository
    {
        private readonly ApiContext _context;
        public EstadoReservaRepository(ApiContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<EstadoReserva>> GetAllAsync() =>
            await _context.EstadoReservas.ToListAsync();

        public async Task<EstadoReserva?> GetByIdAsync(int id) =>
        await _context.EstadoReservas.FindAsync(id);


        public async Task<EstadoReserva> AddAsync(EstadoReserva estadoReserva)
        {
            _context.EstadoReservas.Add(estadoReserva);
            await _context.SaveChangesAsync();
            return estadoReserva;
        }


        public async Task<EstadoReserva?> UpdateAsync(int id, EstadoReserva estadoReserva)
        {
            var existing = await _context.EstadoReservas.FindAsync(id);
            if (existing == null) return null;


            existing.Descripcion = estadoReserva.Descripcion;


            await _context.SaveChangesAsync();
            return existing;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var es = await _context.EstadoReservas.FindAsync(id);
            if (es == null) return false;


            _context.EstadoReservas.Remove(es);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}