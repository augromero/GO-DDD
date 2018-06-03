using System;
using Go.Juegos.Modelos;

namespace Go.Interfaces.Aplicacion
{
    public interface IJuegoIniciador
    {
        Juego IniciarJuego(int tamañoTablero);
    }
}
