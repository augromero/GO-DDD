using System;
using System.Collections.Generic;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class GrupoUnitTest
    {
        [TestMethod]
        public void CreaUnGrupo()
        {
            Guid juegoGuid = new Guid();
            Color color = Color.Negro;
            List<string> piedras = new List<string> { "9X3Y3" };
            List<string> libertades = new List<string> { "9X3Y1", "9X4Y3", "9X3Y4", "9X2Y3" };

            Grupo grupo = new Grupo(juegoGuid, color, piedras, libertades);

            Assert.IsInstanceOfType(grupo.Guid, typeof(Guid));
            Assert.AreEqual("9X3Y3", grupo.Piedras);
            Assert.AreEqual("9X3Y1,9X4Y3,9X3Y4,9X2Y3", grupo.Libertades);
            Assert.AreEqual(1, grupo.PuntosPiedras.Count);
            Assert.AreEqual(4, grupo.PuntosLibertades.Count);
        }
    }
}
