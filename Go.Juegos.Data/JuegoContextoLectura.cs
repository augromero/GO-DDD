using System;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Puntos;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Go.Juegos.Data
{
    public class JuegoContextoLectura : DbContext
    {
        public JuegoContextoLectura(DbContextOptions<JuegoContextoLectura> options) : base(options)
        {
        }

        public DbSet<Piedra> Piedras { get; set; }
        public DbSet<Punto> Puntos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Piedra>()
                        .HasMany(rel => rel.)
        }
    }
}
