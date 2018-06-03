using System;
using Fenix.Excepciones;
using Go.Interfaces.Aplicacion;
using Go.Interfaces.Repositorios;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;

namespace Go.Aplicacion
{
    public class JuegoIniciador : IJuegoIniciador
    {
        private readonly IJuegoRepo _juegoRepo;

        public JuegoIniciador (IJuegoRepo juegoRepo)
        {
            _juegoRepo = juegoRepo;
        }

        public Juego IniciarJuego(int tamañoTablero)
        {
            if (TableroValidador.EsTamañoCorrecto(tamañoTablero) is false)
                throw new FenixExceptionInvalidParameter("El tamaño del tablero es inválido. (tamaños permitidos: 9, 11, 13, 15, 17)");

            Tablero tablero = (Tablero)tamañoTablero;
            Juego juego = new Juego(tablero);

            _juegoRepo.Guardar(juego);

            return juego;
        }
    }
}
