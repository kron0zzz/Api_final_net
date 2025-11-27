using Microsoft.EntityFrameworkCore;
using Api_final.Models;

namespace Api_final.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options) { }


        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<EstadoReserva> EstadoReservas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservas>()
            .HasOne(c => c.EstadoReserva)
            .WithMany()
            .HasForeignKey(c => c.Estado)
            .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
