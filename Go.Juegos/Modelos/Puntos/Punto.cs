using System;
using System.Collections.Generic;
using Go.Juegos.Modelos.Enumerables;

namespace Go.Juegos.Modelos.Puntos
{
    public class Punto
    {
        private Punto()
        {
        }

        public Punto (Tablero tablero, short x, short y)
        {
            Id = CalcularId(tablero, x, y);
            Tablero = tablero;
            X = x;
            Y = y;

            PuntoDerechaId = CalcularNuevoPunto(1, 0);
            PuntoIzquierdaId = CalcularNuevoPunto(-1, 0);
            PuntoArribaId = CalcularNuevoPunto(0, 1);
            PuntoAbajoId = CalcularNuevoPunto(0, -1);


        }

        public string Id { get; private set; }
        public Tablero Tablero { get; private set; }
        public short X { get; private set; }
        public short Y { get; private set; }
        public string PuntoDerechaId { get; private set; }
        public string PuntoIzquierdaId { get; private set; }
        public string PuntoArribaId { get; private set; }
        public string PuntoAbajoId { get; private set; }

        private string CalcularId(Tablero tablero, short x, short y)
        {
            if (EsCoordenadaValida(tablero, x, y) is false)
                throw new ArgumentOutOfRangeException("Coordenada está fuera del tablero.");

          return $"{(short)tablero}X{x}Y{y}";
        }

        private string CalcularNuevoPunto (short movimientoEnX, short movimientoEnY)
        {
            short nuevoX = (short)(X + movimientoEnX);
            short nuevoY = (short)(Y + movimientoEnY);

            if (EsCoordenadaValida(Tablero, nuevoX, nuevoY))
                return CalcularId(Tablero, nuevoX, nuevoY);

            return null;
        }

       
        public List<string> ObtenerConexiones()
        {
            List<string> conexiones = new List<string>
            {
                PuntoIzquierdaId, PuntoDerechaId, PuntoArribaId, PuntoAbajoId
            };

            return conexiones.FindAll(puntoId => puntoId != null);
        }

        private bool EsCoordenadaValida(Tablero tablero, short x, short y)
        {
            if (x > (short)tablero || x <= 0)
                return false;

            if (y > (short)tablero || y <= 0)
                return false;

            return true;
        }

       
    }
}
