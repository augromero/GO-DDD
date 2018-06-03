using System;
using System.Linq;
using Base.Tests;
using Go.Juegos.Data;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Data
{
    [TestClass]
    public class JuegoRepoUnitTest :BaseTestRepositorio<JuegoContexto, JuegoRepo>
    {
        private JuegoRepo _juegoRepo;

        private Juego RetornarJuegoNuevo(Tablero tablero)
        {
            Juego nuevoJuego = new Juego(tablero);
            Guid juegoGuid = _juegoRepo.Guardar(nuevoJuego);
            return _juegoRepo.ObtenerJuego(juegoGuid);
        }

        [TestInitialize]
        public void Inicializar()
        {
            ConectarABaseDatosEnMemoria();
            _juegoRepo = new JuegoRepo(_contexto);
        }

        [TestMethod]
        public void GuardarJuego_EsCorrecto()
        {
            Juego nuevoJuego = new Juego(Tablero.nueveXnueve);
            Guid juegoGuid = _juegoRepo.Guardar(nuevoJuego);

            Juego juegoGuardado = _contexto.Juegos.Find(juegoGuid);

            Assert.AreEqual(1, _contexto.Juegos.Count());
        }

        [TestMethod]
        public void ObtenerJuego_RetornaJuegoPorGuid()
        {
            Juego juegoRetornado = RetornarJuegoNuevo(Tablero.nueveXnueve);

            Assert.IsInstanceOfType(juegoRetornado.Guid, typeof(Guid));

        }
    }
}
