using System;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class MovimientoUnitTest
    {
        [TestMethod]
        public void CreaUnMovimiento()
        {
            Guid juegoGuid = new Guid();
            Color color = Color.Negro;
            string puntoId = "9X1Y1";
            int turno = 1;

            Movimiento movimiento = new Movimiento(juegoGuid, color, puntoId, turno);

            Assert.IsNotNull(movimiento.Guid);
            Assert.AreEqual(juegoGuid, movimiento.JuegoGuid);
            Assert.AreEqual(puntoId, movimiento.PuntoId);
            Assert.AreEqual(turno, movimiento.Turno);
            Assert.IsNotNull(movimiento.FechaRegistro);
        }
    }
}
