using System;
using Go.Interfaces.Dominio;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;

namespace Go.Juegos.Servicios
{
    public class Jugada : IJugada
    {
        private readonly Juego _juego;

        public Jugada(Juego juego)
        {
            _juego = juego;
        }

        public void PonerPiedra(string puntoId)
        {
            PiedraValidador.LanzaExcepcionSiPuntoEstaOcupado(puntoId, _juego.ObtenerPuntosOcupados());

            _juego.AdicionarPiedra(new Piedra(_juego.Guid, _juego.ColorActivo, puntoId));

            _juego.AdicionarMovimiento(new Movimiento(_juego.Guid, _juego.ColorActivo, puntoId, _juego.TurnoActivo));

        }

        public void CambiarTurno()
        {
            _juego.CambioDeTurno();
        }


    }
}
