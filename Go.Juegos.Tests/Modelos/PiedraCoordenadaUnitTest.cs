using System;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;
using Go.Juegos.Servicios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class PiedraCoordenadaUnitTest
    {
        [TestMethod]
        public void PiedraConexiones_CreaPiedraConPuntosConectadosAElla()
        {
            Guid juegoGuid = new Guid();
            Piedra piedra = new Piedra(juegoGuid, Color.Blanco, "9X2Y3");

            Punto punto = new Punto(Tablero.nueveXnueve, 2, 3);

            PiedraCoordenada piedraConexiones = new PiedraCoordenada(piedra, punto);

            Assert.AreEqual(Color.Blanco, piedraConexiones.Color);
            Assert.AreEqual("9X2Y3", piedraConexiones.IdPunto);
            Assert.AreEqual(2, piedraConexiones.X);
            Assert.AreEqual(3, piedraConexiones.Y);
            Assert.AreEqual(4, piedraConexiones.CantidadConexiones);
        }
    }
}
