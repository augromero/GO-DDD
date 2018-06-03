using System;
using Go.Interfaces.Aplicacion;
using Go.Interfaces.Repositorios;
using Go.Juegos.Modelos;

namespace Go.Aplicacion
{
    public class Partida : IPartida
    {
        private readonly IJuegoRepo _juegoRepo;

        public Partida(IJuegoRepo juegoRepo)
        {
            _juegoRepo = juegoRepo;
        }

        public Juego JugarPiedra(Guid juegoGuid, string puntoId)
        {
            Juego juego = _juegoRepo.ObtenerJuego(juegoGuid);
            juego.PonerPiedra(puntoId);

            _juegoRepo.GuardarCambios();

            return juego;
        }
    }
}
