using System;
using System.Collections.Generic;
using System.Linq;
using Go.Juegos.Modelos.Enumerables;

namespace Go.Juegos.Modelos.Puntos
{
    public static class PuntosTablero
    {
        public static List<Punto> CrearPuntosTablero(Tablero tablero)
        {
            List<Punto> puntosTablero = new List<Punto>();
            for (int x = 1; x <= (int)tablero; x++)
            {
                for (int y = 1; y <= (int)tablero; y++)
                {
                    puntosTablero.Add(new Punto(tablero, x, y));
                }
            }

            return puntosTablero;
        }

        public static bool ExistePuntoIdEnTablero(string puntoId, Tablero tablero)
        {
            List<string> puntosIdPorTablero = CrearPuntosTablero(tablero).Select(punto => punto.Id).ToList();

            return puntosIdPorTablero.Contains(puntoId);
        }
    }
}
