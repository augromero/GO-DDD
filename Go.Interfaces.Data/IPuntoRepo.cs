using System;
using System.Collections.Generic;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;

namespace Go.Interfaces.Data
{
    public interface IPuntoRepo
    {
        void AgregarPuntos(List<Punto> puntos);
        List<Punto> ObtenerPuntosTablero(Tablero tablero);
        bool ExistePuntoEnTablero(string puntoId, Tablero tablero);
        bool ExisteTableroCreado(Tablero tamañoTablero);
        Punto ObtenerPuntoPorId(string id);
        List<Punto> ObtenerPuntosPorIds(List<string> idsPuntos);
    }
}
