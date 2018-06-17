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
            for (short x = 1; x <= (short)tablero; x++)
            {
                for (short y = 1; y <= (short)tablero; y++)
                {
                    puntosTablero.Add(new Punto(tablero, x, y));
                }
            }

            return puntosTablero;
        }

       
    }
}
