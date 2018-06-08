using System;
using System.Collections.Generic;
using Fenix.Excepciones;
using Go.Interfaces.Aplicacion;
using Go.Interfaces.Data;
using Go.Interfaces.Dominio;
using Go.Juegos.Modelos;
using Go.Juegos.Servicios;

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
            Jugada jugada = new Jugada(juego);

            jugada.PonerPiedra(puntoId);


            GrupoCreador grupoCreador = new GrupoCreador(juego);
            List<Grupo> gruposNuevos = grupoCreador.AgruparPiedras(_puntoRepo.ObtenerPuntoPorId(puntoId));
            juego.ActualizarGrupos(gruposNuevos);

            jugada.CambiarTurno();
           
            _juegoRepo.GuardarCambios();

            return juego;
        }
    }
}
