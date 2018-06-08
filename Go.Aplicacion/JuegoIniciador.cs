using System;
using System.Collections.Generic;
using Fenix.Excepciones;
using Go.Interfaces.Aplicacion;
using Go.Interfaces.Data;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;

namespace Go.Aplicacion
{
    public class JuegoIniciador : IJuegoIniciador
    {
        private readonly IJuegoRepo _juegoRepo;
        private readonly IPuntoRepo _puntoRepo;

        public JuegoIniciador (IJuegoRepo juegoRepo, IPuntoRepo puntoRepo)
        {
            _juegoRepo = juegoRepo;
            _puntoRepo = puntoRepo;
        }

        public Juego IniciarJuego(int tamañoTablero)
        {
            if (TableroValidador.EsTamañoCorrecto(tamañoTablero) is false)
                throw new FenixExceptionInvalidParameter("El tamaño del tablero es inválido. (tamaños permitidos: 9, 11, 13, 15, 17)");

            Tablero tablero = (Tablero)tamañoTablero;

            PrepararPartida(tablero);

            Juego juego = new Juego(tablero);

            _juegoRepo.Guardar(juego);

            return juego;
        }

        public void PrepararPartida(Tablero tablero)
        {
            if (_puntoRepo.ExisteTableroCreado(tablero))
                return;

            List<Punto> puntosTablero = PuntosTablero.CrearPuntosTablero(tablero);
            _puntoRepo.AgregarPuntos(puntosTablero);
        }
    }
}
