using System;
using System.Collections.Generic;
using System.Linq;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class JuegoUnitTest
    {

        [TestMethod]
        public void CreaUnNuevoJuego()
        {
            Juego juego = new Juego(Tablero.nueveXnueve);

            Assert.IsNotNull(juego.Guid);
            Assert.AreEqual(Tablero.nueveXnueve, juego.Tablero);
            Assert.AreEqual(Color.Negro, juego.ColorActivo);
            Assert.AreEqual(1, juego.TurnoActivo);
            Assert.AreEqual(0, juego.Piedras.Count);
            Assert.AreEqual(0, juego.Movimientos.Count);
        }

        [TestMethod]
        public void ObtenerPuntosOcupados_RetornaListaPuntosId()
        {
            Juego juego = new Juego(Tablero.nueveXnueve);
            juego.PonerPiedra("9X2Y2");
            List<string> puntosOcupados = juego.ObtenerPuntosOcupados();

            Assert.IsTrue((new List<string> { "9X2Y2" }).SequenceEqual(puntosOcupados));
        }

        [TestMethod]
        public void PonerPiedra_cuandoMovimientoEsValido_AdicionNuevaPiedraRegistraMovimientoYCambiaTurno()
        {
            Juego juego = new Juego(Tablero.nueveXnueve);
            string puntoId = "9X2Y2";

            juego.PonerPiedra(puntoId);

            Assert.AreEqual(1, juego.Piedras.Count());
            Assert.AreEqual(1, juego.Movimientos.Count());
            Assert.AreEqual(Color.Blanco, juego.ColorActivo);
            Assert.AreEqual(2, juego.TurnoActivo);

        }
    }
}
