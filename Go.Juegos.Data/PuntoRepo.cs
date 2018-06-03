using System;
using System.Collections.Generic;
using System.Linq;
using Go.Interfaces.Repositorios;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;
using Microsoft.EntityFrameworkCore;

namespace Go.Juegos.Data
{
    public class PuntoRepo : IPuntoRepo
    {
        private readonly JuegoContexto _contexto;

        public PuntoRepo(JuegoContexto contexto)
        {
            _contexto = contexto;
        }

        public void AgregarPuntos(List<Punto> puntos)
        {
            _contexto.AddRange(puntos);
        }

        public List<Punto> ObtenerPuntosTablero(Tablero tablero)
        {
            return _contexto.Puntos.Where(punto => punto.Tablero == tablero)
                     .AsNoTracking()
                     .ToList();
        }

        public bool ExistePuntoEnTablero(string puntoId, Tablero tablero)
        {
            return _contexto.Puntos
                            .Any(punto => punto.Id == puntoId
                                 && punto.Tablero == tablero);
        }

        public bool ExisteTableroCreado(Tablero tablero)
        {
            return _contexto.Puntos
                            .Any(punto => punto.Tablero == tablero);
        }
    }
}
