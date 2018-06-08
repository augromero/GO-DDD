using System;
using System.Collections.Generic;
using System.Linq;
using Fenix.Excepciones;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Servicios;
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
            Jugada jugada = new Jugada(juego);
            jugada.PonerPiedra("9X2Y2");
            List<string> puntosOcupados = juego.ObtenerPuntosOcupados();

            Assert.IsTrue((new List<string> { "9X2Y2" }).SequenceEqual(puntosOcupados));
        }

        [TestMethod]
        public void ObtenerPuntosOcupados_CuandoNoHyaPiedras_RetornaListaVacia()
        {
            Juego juego = new Juego(Tablero.nueveXnueve);

            List<string> puntosOcupados = juego.ObtenerPuntosOcupados();

            Assert.AreEqual(0, puntosOcupados.Count);
        }

        [TestMethod]
        public void ObtenerPiedrasPorColor_RetornaListaDePiedras()
        {
            Juego juego = new Juego(Tablero.nueveXnueve);
            Jugada jugada = new Jugada(juego);

            jugada.PonerPiedra("9X2Y2");
            jugada.CambiarTurno();
            jugada.PonerPiedra("9X7Y7");
            jugada.CambiarTurno();
            jugada.PonerPiedra("9X3Y3");
            jugada.CambiarTurno();
            
            List<Piedra> piedrasPorColor = juego.ObtenerPiedrasPorColor(Color.Negro);

            Assert.AreEqual(2, piedrasPorColor.Count);
        }

        [TestMethod]
        public void ActualizarGrupos_EliminaYGuardaNuevasAgrupaciones()
        {
            Juego juego = new Juego(Tablero.nueveXnueve);

            List<Grupo> nuevosGrupos = new List<Grupo>
            {
                new Grupo(juego.Guid, Color.Negro, new List<string> {"9X1Y1"}, new List<string> {"9X2Y1", "9X1Y2"} ),
                new Grupo(juego.Guid, Color.Blanco, new List<string> {"9X9Y9"}, new List<string> {"9X9Y8", "9X8Y9"} )
            };

            juego.ActualizarGrupos(nuevosGrupos);

            Assert.AreEqual(2, juego.Grupos.Count);
        }
    }

}
