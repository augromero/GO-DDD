using System;
using Go.Interfaces.Repositorios;
using Go.Aplicacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos;

namespace Go.Juegos.Tests.Aplicacion
{
    [TestClass]
    public class PartidaUnitTest
    {
        private Mock<IJuegoRepo> _juegoRepo;

        private Partida _partida; 

        [TestInitialize]
        public void Inicializar()
        {
            _juegoRepo = new Mock<IJuegoRepo>();

            _partida = new Partida(_juegoRepo.Object);
        }


        [TestMethod]
        public void JugarPiedra_CuandoEsValido_GuardaPiedra()
        {
            Guid juegoGuid = new Guid();
            string punto = "9X2Y2";

            _juegoRepo.Setup(metodo => metodo.ObtenerJuego(juegoGuid))
                      .Returns(new Juego(Tablero.nueveXnueve));

            Juego juegoConJugada = _partida.JugarPiedra(juegoGuid, punto);

            _juegoRepo.Verify(metodo => metodo.GuardarCambios(), Times.Once());

            Assert.AreEqual(1, juegoConJugada.Movimientos.Count);
        }
    }
}
