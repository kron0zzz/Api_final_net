using Microsoft.EntityFrameworkCore;
using Api_final.Models;

namespace Api_final.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options) { }


        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<EstadoReserva> EstadoReservas { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Users> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fk hacia Estado
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservas>()
            .HasOne(c => c.EstadoReserva)
            .WithMany()
            .HasForeignKey(c => c.Estado)
            .OnDelete(DeleteBehavior.Cascade);


            //Fk hacia Clientes
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservas>()
            .HasOne(c => c.Clientes)
            .WithMany()
            .HasForeignKey(c => c.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);


            //Fk hacia servicios
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservas>()
            .HasOne(c => c.Servicios)
            .WithMany()
            .HasForeignKey(c => c.IdServicio)
            .OnDelete(DeleteBehavior.Cascade);
        }


        

    }
}
