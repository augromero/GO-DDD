using System;
using System.Collections.Generic;
using Fenix.Excepciones;
using Go.Aplicacion;
using Go.Interfaces.Data;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Go.Juegos.Tests.Aplicacion
{
    [TestClass]
    public class JuegoIniciadorUnitTest
    {
        private Mock<IJuegoRepo> _juegoRepo;
        private Mock<IPuntoRepo> _puntoRepo;

        private JuegoIniciador _juegoIniciador;

        [TestInitialize]
        public void Inicializar()
        {
            _juegoRepo = new Mock<IJuegoRepo>();
            _puntoRepo = new Mock<IPuntoRepo>();

            _juegoIniciador = new JuegoIniciador(_juegoRepo.Object, _puntoRepo.Object);

        }

        [TestMethod]
        public void IniciarJuego_CunadoTamañoTableroEsCorrecto_CreaUnJuegoNuevo()
        {
            int tamañoTablero = 9;

            Juego juego = _juegoIniciador.IniciarJuego(tamañoTablero);

            _juegoRepo.Verify(metodo => metodo.Guardar(It.IsAny<Juego>()), Times.Once());

            Assert.IsInstanceOfType(juego, typeof(Juego));
        }

        [TestMethod]
        [ExpectedException(typeof(FenixExceptionInvalidParameter), "El tamaño del tablero es incorrecto. (Valores aceptados: 9, 11, 13, 15, 17, 19)")]
        public void IniciarJuego_CuandoTamañoTableroEsIncorrecto_LanzaExcepcion()
        {
            int tamañoTablero = 7;
            Guid juegoGuidEsperado = new Guid();

            _juegoRepo.Setup(metodo => metodo.Guardar(It.IsAny<Juego>()))
                      .Returns(juegoGuidEsperado);

            Juego juego = _juegoIniciador.IniciarJuego(tamañoTablero);
        }

        [TestMethod]
        public void PrepararPartida_CuandoPuntosTableroNoExisten_AdicionaPuntos()
        {
            Tablero tablero = Tablero.nueveXnueve;

            _puntoRepo.Setup(metodo => metodo.ExisteTableroCreado(tablero))
                      .Returns(false);

            _juegoIniciador.PrepararPartida(tablero);

            _puntoRepo.Verify(metodo => metodo.AgregarPuntos(It.IsNotNull<List<Punto>>()), Times.Once());
        }

        [TestMethod]
        public void PrepararPartida_CuandoPuntosTableroExisten_NoEjecutaAcciones()
        {
            Tablero tablero = Tablero.nueveXnueve;

            _puntoRepo.Setup(metodo => metodo.ExisteTableroCreado(tablero))
                      .Returns(true);

            _juegoIniciador.PrepararPartida(tablero);

            _puntoRepo.Verify(metodo => metodo.AgregarPuntos(It.IsAny<List<Punto>>()), Times.Never());
        }
    }
}
