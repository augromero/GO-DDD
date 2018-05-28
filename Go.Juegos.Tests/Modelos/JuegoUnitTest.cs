using System;
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
            Assert.IsNull(juego.Piedras);
        }
    }
}
