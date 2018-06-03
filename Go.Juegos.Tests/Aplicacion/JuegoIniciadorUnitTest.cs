using System;
using Fenix.Excepciones;
using Go.Aplicacion;
using Go.Interfaces.Repositorios;
using Go.Juegos.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Go.Juegos.Tests.Aplicacion
{
    [TestClass]
    public class JuegoIniciadorUnitTest
    {
        private Mock<IJuegoRepo> _juegoRepo;

        private JuegoIniciador _juegoIniciador;

        [TestInitialize]
        public void Inicializar()
        {
            _juegoRepo = new Mock<IJuegoRepo>();

            _juegoIniciador = new JuegoIniciador(_juegoRepo.Object);

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
    }
}
