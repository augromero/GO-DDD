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

        public Punto (Tablero tablero, int x, int y)
        {
            Id = CalcularId(tablero, x, y);
            Tablero = tablero;
            X = x;
            Y = y;

            PuntoDerechaId = CalcularPuntoDerecha();
            PuntoIzquierdaId = CalcularPuntoIzquierda();
            PuntoArribaId = CalcularPuntoArriba();
            PuntoAbajoId = CalcularPuntoAbajo();


        }

        public string Id { get; private set; }
        public Tablero Tablero { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public string PuntoDerechaId { get; private set; }
        public string PuntoIzquierdaId { get; private set; }
        public string PuntoArribaId { get; private set; }
        public string PuntoAbajoId { get; private set; }

        private string CalcularId(Tablero tablero, int x, int y)
        {
            if (x > (short)tablero || x <= 0)
                throw new ArgumentOutOfRangeException("Coordenada está fuera del tablero.");

            if (y > (short)tablero || y <= 0)
                throw new ArgumentOutOfRangeException("Coordenada está fuera del tablero.");

            return $"{(short)tablero}X{x}Y{y}";
        }

        private string CalcularPuntoDerecha()
        {
            try
            {
                return CalcularId(Tablero, X + 1, Y);
            }
            catch(ArgumentOutOfRangeException)
            {
                return null;
            }

        }

        private string CalcularPuntoIzquierda()
        {
            try
            {
                return CalcularId(Tablero, X - 1, Y);

            }
            catch(ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        private string CalcularPuntoArriba()
        {
            try
            {
                return CalcularId(Tablero, X, Y + 1);

            }
            catch(ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        private string CalcularPuntoAbajo()
        {
            try
            {
                return CalcularId(Tablero, X, Y - 1);
                }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        public List<string> ObtenerConexiones()
        {
            List<string> conexiones = new List<string>
            {
                PuntoIzquierdaId, PuntoDerechaId, PuntoArribaId, PuntoAbajoId
            };

            return conexiones.FindAll(puntoId => puntoId != null);
        }

    }
}
