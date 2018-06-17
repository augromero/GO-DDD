using System;
using System.Linq;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;

namespace Go.Juegos.Modelos
{
    public class PiedraCoordenada
    {
       

        public PiedraCoordenada(Piedra piedra, Punto punto)
        {
            Color = piedra.Color;
            IdPunto = piedra.PuntoId;
            X = punto.X;
            Y = punto.Y;
            CantidadConexiones = (short)punto.ObtenerConexiones().Count();
        }

        public Color Color { get; private set; }
        public string IdPunto { get; private set; }
        public short X { get; private set; }
        public short Y { get; private set; }
        public short CantidadConexiones { get; private set; }
    }
}
