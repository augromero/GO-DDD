using System;
namespace Go.Juegos.Modelos.Puntos
{
    public class PuntoInexistenteException : ApplicationException
    {
        public PuntoInexistenteException(string message) : base("El punto no existe en el tablero.")
        {
        }
    }
}
