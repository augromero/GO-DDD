using System;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;
using Microsoft.EntityFrameworkCore;

namespace Go.Juegos.Data
{
    public class JuegoContexto : DbContext
    {

        public JuegoContexto(DbContextOptions<JuegoContexto> options) : base(options)
        {
        }

        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Piedra> Piedras { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Punto> Puntos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Juego>()
                        .HasKey(propiedad => propiedad.Guid);
            modelBuilder.Entity<Juego>().Property(propiedad => propiedad.ColorActivo)
                        .HasConversion(
                            color => color.ToString(),
                            color => (Color)Enum.Parse(typeof(Color), color));

            modelBuilder.Entity<Juego>()
                        .ToTable("Juegos")
                        .HasMany(rel => rel.Piedras)
                        .WithOne();

            modelBuilder.Entity<Piedra>()
                        .ToTable("Piedras")
                        .HasKey(propiedad => propiedad.Guid);

            modelBuilder.Entity<Piedra>()
                        .Property(propiedad => propiedad.Color)
                        .HasConversion(
                            color => color.ToString(),
                            color => (Color)Enum.Parse(typeof(Color), color));

            modelBuilder.Entity<Movimiento>()
                        .ToTable("Movimientos")
                        .HasKey(propiedad => propiedad.Guid);
            
            modelBuilder.Entity<Movimiento>()
                        .Property(propiedad => propiedad.Color)
                        .HasConversion(
                            color => color.ToString(),
                            color => (Color)Enum.Parse(typeof(Color), color));

            modelBuilder.Entity<Punto>()
                        .HasKey(propiedad => propiedad.Id);

        }
    }
}
