using Go.Aplicacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos;
using Fenix.Excepciones;
using Go.Interfaces.Data;
using Go.Juegos.Modelos.Puntos;

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
            string punto = "9X2Y2";

            Juego juego = new Juego(Tablero.nueveXnueve);

            _juegoRepo.Setup(metodo => metodo.ObtenerJuego(juego.Guid))
                      .Returns(juego);
            _puntoRepo.Setup(metodo => metodo.ExistePuntoEnTablero(punto, Tablero.nueveXnueve))
                      .Returns(true);
            _puntoRepo.Setup(metodo => metodo.ObtenerPuntoPorId(punto))
                      .Returns(new Punto(Tablero.nueveXnueve, 2, 2));


            Juego juegoConJugada = _partida.JugarPiedra(juego.Guid, punto);

            _juegoRepo.Verify(metodo => metodo.GuardarCambios(), Times.Once());

            Assert.AreEqual(1, juegoConJugada.Movimientos.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(FenixExceptionInvalidParameter), "El punto no existe en el tablero.")]
        public void JugarPiedra_CuandoPuntoNoEsDelTablero_RetornaError()
        {
            Juego juego = new Juego(Tablero.nueveXnueve);
            string punto = "9X2Y2";

            _juegoRepo.Setup(metodo => metodo.ObtenerJuego(juego.Guid))
                     .Returns(new Juego(Tablero.nueveXnueve));
            _puntoRepo.Setup(metodo => metodo.ExistePuntoEnTablero(punto, Tablero.nueveXnueve))
                      .Returns(false);

            Juego juegoConJugada = _partida.JugarPiedra(juego.Guid, punto);
        }
    }
}
