using System;
using System.Linq;
using Fenix.Excepciones;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Servicios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class JugadaUnitTest
    {
        private Juego _juego;
        private Jugada _jugada;

        [TestInitialize]
        public void Inicializar()
        {
            _juego = new Juego(Tablero.nueveXnueve);
            _jugada = new Jugada(_juego);

        }

        [TestMethod]
        public void PonerPiedra_cuandoMovimientoEsValido_AdicionNuevaPiedraYRegistraMovimiento()
        {
            string puntoId = "9X2Y2";

            _jugada.PonerPiedra(puntoId);

            Assert.AreEqual(1, _juego.Piedras.Count());
            Assert.AreEqual(1, _juego.Movimientos.Count());

        }

        [TestMethod]
        [ExpectedException(typeof(FenixExceptionConflict), "El punto está ocupado por otra piedra.")]
        public void PonerPiedra_CuandoPuntoEstaOcupado_RetornaError()
        {
            string puntoId = "9X2Y2";

            _jugada.PonerPiedra(puntoId);
            _jugada.PonerPiedra(puntoId);
        }
    }
}
