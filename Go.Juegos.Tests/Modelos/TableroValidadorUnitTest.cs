using System;
using Go.Juegos.Modelos.Enumerables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class TableroValidadorUnitTest
    {
        [TestMethod]
        public void EsTamañoCorrecto_CuandoCorrespondeATamaño_RetornaTrue()
        {
            Assert.IsTrue(TableroValidador.EsTamañoCorrecto(9));
        }

        [TestMethod]
        public void EsTamañoCorrecto_CuandoNoCorresponde_RetornaFalse()
        {
            Assert.IsFalse(TableroValidador.EsTamañoCorrecto(7));
        }
    }
}
