using Microsoft.EntityFrameworkCore;
using TorreDeControl.Core.Domain.Entities;

namespace TorreDeControl.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Aeropuerto> Aeropuerto { get; set; }
        public DbSet<Avión> Avión { get; set; }
        public DbSet<Pasajero> Pasajeros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region tables

            modelBuilder.Entity<Aeropuerto>()
                .ToTable("Aeropuerto");

            modelBuilder.Entity<Avión>()
                .ToTable("Avión");

            modelBuilder.Entity<Pasajero>()
                .ToTable("Pasajero");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Aeropuerto>()
                .HasKey(aeropuerto => aeropuerto.idAeropuerto);

            modelBuilder.Entity<Avión>()
                .HasKey(avión => avión.idAvión);

            modelBuilder.Entity<Pasajero>()
                .HasKey(pasajero => pasajero.idPasajero);
            #endregion

            #region "Relationships"
            modelBuilder.Entity<Aeropuerto>()
                .HasMany<Avión>(avión => avión.Aviones)
                .WithOne(aeropuerto => aeropuerto.Aeropuerto)
                .HasForeignKey(aeropuerto => aeropuerto.FKaeropuerto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Avión>()
                .HasMany<Pasajero>(pasajero => pasajero.Pasajeros)
                .WithOne(avión => avión.Avión)
                .HasForeignKey(avión => avión.FKavión)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region "Property configurations"

            #region Aeropuerto

            modelBuilder.Entity<Aeropuerto>().
                Property(aeropuerto => aeropuerto.nombreAeropuerto)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Aeropuerto>().
               Property(aeropuerto => aeropuerto.límiteAviones)
               .IsRequired();

            #endregion
            #region Avión
            modelBuilder.Entity<Avión>().
              Property(avión => avión.nombreAvión)
              .IsRequired()
              .HasMaxLength(50);

            modelBuilder.Entity<Avión>().
              Property(avión => avión.horaDeSalida)
              .IsRequired();

            modelBuilder.Entity<Avión>().
              Property(avión => avión.horaDeLlegada)
              .IsRequired();

            modelBuilder.Entity<Avión>().
              Property(avión => avión.aeropuertoDeLlegada)
              .IsRequired();

            modelBuilder.Entity<Avión>().
              Property(avión => avión.aeropuertoDeSalida)
              .IsRequired();

            modelBuilder.Entity<Avión>().
              Property(avión => avión.límitePasajeros)
              .IsRequired();

            modelBuilder.Entity<Avión>().
              Property(avión => avión.pesoLímite)
              .IsRequired();

            modelBuilder.Entity<Avión>().
              Property(avión => avión.estadoDelAvión)
              .IsRequired();
            #endregion
            #region Pasajero

            modelBuilder.Entity<Pasajero>().
                Property(pasajero => pasajero.nombrePasajero)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<Pasajero>().
               Property(pasajero => pasajero.pesoPasajero)
               .IsRequired();

            #endregion
            #endregion
        }
    }
}