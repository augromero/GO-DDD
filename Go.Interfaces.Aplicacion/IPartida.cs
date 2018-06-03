using System;
using Go.Juegos.Modelos;

namespace Go.Interfaces.Aplicacion
{
    public interface IPartida
    {
        Juego JugarPiedra(Guid juegoGuid, string puntoId);
    }
}
