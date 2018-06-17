using System;
using System.Collections.Generic;
using Base.Tests;
using Go.Juegos.Data;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Data
{
    [TestClass]
    public class PuntoRepoUnitTest :BaseTestRepositorio<JuegoContexto, JuegoRepo>
    {
        private PuntoRepo _puntoRepo;
        [TestInitialize]
        public void Inicializar()
        {
            ConectarABaseDatosEnMemoria();

            _puntoRepo = new PuntoRepo(_contexto);
        }

        private int CrearPuntosTablero(Tablero tablero)
        {
            List<Punto> puntos = PuntosTablero.CrearPuntosTablero(tablero);

            _puntoRepo.AgregarPuntos(puntos);
            int puntosCreados = _contexto.SaveChanges();
            return puntosCreados;
        }

        [TestMethod]
        public void GuardarPuntos_PersisteListaPuntos()
        {
            int puntosCreados = CrearPuntosTablero(Tablero.nueveXnueve);

            Assert.AreEqual(81, puntosCreados);

        }

        [TestMethod]
        public void ObtenerPuntosPorTablero_RetornaListaPuntosTablero()
        {
            CrearPuntosTablero(Tablero.nueveXnueve);
            CrearPuntosTablero(Tablero.onceXonce);

            List<Punto> puntos9x9 = _puntoRepo.ObtenerPuntosTablero(Tablero.nueveXnueve);

            Assert.AreEqual(81, puntos9x9.Count);
        }

        [TestMethod]
        public void ExistePuntoEnTablero_CunadoExiste_RetornaTrue()
        {
            CrearPuntosTablero(Tablero.nueveXnueve);

            Assert.IsTrue(_puntoRepo.ExistePuntoEnTablero("9X2Y2", Tablero.nueveXnueve));
        }

        [TestMethod]
        public void ExistePuntoEnTablero_CuandoNoExiste_RetornaFalse()
        {
            CrearPuntosTablero(Tablero.nueveXnueve);

            Assert.IsFalse(_puntoRepo.ExistePuntoEnTablero("NoExiste", Tablero.nueveXnueve));
        }

        [TestMethod]
        public void ExistePuntoEnTablero_CuandoExisteEnOtroTablero_RetornaFalse()
        {
            CrearPuntosTablero(Tablero.nueveXnueve);
            CrearPuntosTablero(Tablero.onceXonce);

            Assert.IsFalse(_puntoRepo.ExistePuntoEnTablero("11X1Y1", Tablero.nueveXnueve));
        }

        [TestMethod]
        public void ExisteTableroCreado_CuandoNoEncuentraPuntos_RetornaFalse()
        {
            Assert.IsFalse(_puntoRepo.ExisteTableroCreado(Tablero.nueveXnueve));
        }

        [TestMethod]
        public void ObtenerPuntosPorIds_RetornaPuntosDeUnaListaDeIds()
        {
            CrearPuntosTablero(Tablero.nueveXnueve);

            List<string> idsPuntos = new List<string> { "9X1Y2", "9X3Y4" };

            List<Punto> puntos = _puntoRepo.ObtenerPuntosPorIds(idsPuntos);

            Assert.AreEqual(2, puntos.Count);
        }

    }
}
