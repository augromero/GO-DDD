using System;
using Go.Interfaces.Repositorios;
using Go.Aplicacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos;
using Fenix.Excepciones;

namespace Go.Juegos.Tests.Aplicacion
{
    [TestClass]
    public class PartidaUnitTest
    {
        private Mock<IJuegoRepo> _juegoRepo;
        private Mock<IPuntoRepo> _puntoRepo;

        private Partida _partida; 

        [TestInitialize]
        public void Inicializar()
        {
            _juegoRepo = new Mock<IJuegoRepo>();
            _puntoRepo = new Mock<IPuntoRepo>();

            _partida = new Partida(_juegoRepo.Object, _puntoRepo.Object);
        }


        [TestMethod]
        public void JugarPiedra_CuandoEsValido_GuardaPiedra()
        {
            Guid juegoGuid = new Guid();
            string punto = "9X2Y2";

            _juegoRepo.Setup(metodo => metodo.ObtenerJuego(juegoGuid))
                      .Returns(new Juego(Tablero.nueveXnueve));
            _puntoRepo.Setup(metodo => metodo.ExistePuntoEnTablero(punto, Tablero.nueveXnueve))
                      .Returns(true);

            Juego juegoConJugada = _partida.JugarPiedra(juegoGuid, punto);

            _juegoRepo.Verify(metodo => metodo.GuardarCambios(), Times.Once());

            Assert.AreEqual(1, juegoConJugada.Movimientos.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(FenixExceptionInvalidParameter), "El punto no existe en el tablero.")]
        public void JugarPiedra_CuandoPuntoNoEsDelTablero_RetornaError()
        {
            Guid juegoGuid = new Guid();
            string punto = "9X2Y2";

            _juegoRepo.Setup(metodo => metodo.ObtenerJuego(juegoGuid))
                     .Returns(new Juego(Tablero.nueveXnueve));
            _puntoRepo.Setup(metodo => metodo.ExistePuntoEnTablero(punto, Tablero.nueveXnueve))
                      .Returns(false);

            Juego juegoConJugada = _partida.JugarPiedra(juegoGuid, punto);
        }
    }
}
