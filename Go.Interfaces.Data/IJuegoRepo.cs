using System;
using System.Collections.Generic;
using Go.Juegos.Modelos;

namespace Go.Interfaces.Data
{
    public interface IJuegoRepo
    {
        Guid Guardar(Juego juego);
        Juego ObtenerJuego(Guid juegoGuid);
        void GuardarCambios();
        List<Piedra> ObtenerPiedrasJuego(Guid juegoGuid);
    }
}
