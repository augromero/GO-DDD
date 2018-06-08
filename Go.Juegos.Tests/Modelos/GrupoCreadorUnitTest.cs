using System;
using System.Collections.Generic;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;
using Go.Juegos.Servicios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class GrupoCreadorUnitTest
    {
        private Juego _juego;
        private GrupoCreador _grupoCreador;

        [TestInitialize]
        public void Inicializar()
        {
            _juego = new Juego(Tablero.nueveXnueve);
            _grupoCreador = new GrupoCreador(_juego);
        }

        [TestMethod]
        public void GrupoCreador_CuandoPonePrimeraPiedra_CreaUnGrupoDeUnaPiedraConSusLibertades()
        {
            Punto punto = new Punto(Tablero.nueveXnueve, 2, 2);
           
            List<Grupo> gruposNegros = new List<Grupo>();

            List<Grupo> gruposNuevos = _grupoCreador.AgruparPiedras(punto);

            Assert.AreEqual(1, gruposNuevos.Count);
            Assert.AreEqual(4, gruposNuevos[0].PuntosLibertades.Count);
        }
    }
}
