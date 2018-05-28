using System;
namespace Go.Juegos.Modelos.Puntos
{
    public class PuntoOcupadoException : ApplicationException
    {
        public PuntoOcupadoException(string message) : base("El punto ya se encuentra ocupado por otra piedra.")
        {
        }
    }
}
