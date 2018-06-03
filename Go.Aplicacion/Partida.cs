using System;
using Fenix.Excepciones;
using Go.Interfaces.Aplicacion;
using Go.Interfaces.Repositorios;
using Go.Juegos.Modelos;

namespace Go.Aplicacion
{
    public class Partida : IPartida
    {
        private readonly IJuegoRepo _juegoRepo;
        private readonly IPuntoRepo _puntoRepo;

        public Partida(IJuegoRepo juegoRepo, IPuntoRepo puntoRepo)
        {
            _juegoRepo = juegoRepo;
            _puntoRepo = puntoRepo;
        }

       
        public Juego JugarPiedra(Guid juegoGuid, string puntoId)
        {
            Juego juego = _juegoRepo.ObtenerJuego(juegoGuid);

            if (_puntoRepo.ExistePuntoEnTablero(puntoId, juego.Tablero) is false)
                throw new FenixExceptionInvalidParameter("El punto no se encuentra en el tablero.");

            juego.PonerPiedra(puntoId);

            _juegoRepo.GuardarCambios();

            return juego;
        }
    }
}
