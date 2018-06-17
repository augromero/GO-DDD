using System;
using System.Collections.Generic;
using System.Linq;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;
using Go.Juegos.Servicios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class PiedraConectorUnitTest
    {
        private PiedraConector _piedraConector;
        private Guid _juegoGuid;
        private Tablero _tablero;

        [TestInitialize]
        public void Inicializar()
        {
            _piedraConector = new PiedraConector();
            _juegoGuid = new Guid();
            _tablero = Tablero.nueveXnueve;
        }

        [TestMethod]
        public void RelacionarPiedrasJuego_CuandoPiedras_N22_B23_RetornaDosConexionesEnemigas()
        {
            List<PiedraCoordenada> piedrasJuego = new List<PiedraCoordenada>()
            {
                new PiedraCoordenada(new Piedra(_juegoGuid, Color.Negro, "9X2Y2"), new Punto(_tablero, 2, 2)),
                new PiedraCoordenada(new Piedra(_juegoGuid, Color.Blanco, "9X2Y3"), new Punto(_tablero, 2, 3)),
            };
            List<PiedraConexion> conexiones = _piedraConector.RelacionarPiedrasJuego(piedrasJuego);

            Assert.AreEqual(2, conexiones.Count);
            Assert.IsTrue(conexiones.TrueForAll(conexion => conexion.TipoConexion == TipoConexionPiedra.Enemiga));
        }

        [TestMethod]
        public void RelacionarPiedrasJuego_CuandoPiedras_B33_N22_B23_RetornaDosConexionesEnemigas_DosAmigas()
        {
            List<PiedraCoordenada> piedrasJuego = new List<PiedraCoordenada>()
            {
                new PiedraCoordenada(new Piedra(_juegoGuid, Color.Blanco, "9X3Y3"), new Punto(_tablero, 3, 3)),
                new PiedraCoordenada(new Piedra(_juegoGuid, Color.Negro, "9X2Y2"), new Punto(_tablero, 2, 2)),
                new PiedraCoordenada(new Piedra(_juegoGuid, Color.Blanco, "9X2Y3"), new Punto(_tablero, 2, 3)),
            };
            List<PiedraConexion> conexiones = _piedraConector.RelacionarPiedrasJuego(piedrasJuego);

            Assert.AreEqual(4, conexiones.Count);
            Assert.AreEqual(2, conexiones.Where(conexion => conexion.TipoConexion == TipoConexionPiedra.Enemiga).Count());
            Assert.AreEqual(2, conexiones.Where(conexion => conexion.TipoConexion == TipoConexionPiedra.Amiga).Count());
        }
    }
}
