using System;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class PiedraUnitTest
    {
        [TestMethod]
        public void CreaUnaPiedra()
        {
            Piedra piedra = new Piedra(new Guid(), Color.Negro, "9X1Y1");

            Assert.IsNotNull(piedra.Guid);
            Assert.IsNotNull(piedra.JuegoGuid);
            Assert.AreEqual(Color.Negro, piedra.Color);
            Assert.AreEqual("9X1Y1", piedra.PuntoId);

        }


    }
}
