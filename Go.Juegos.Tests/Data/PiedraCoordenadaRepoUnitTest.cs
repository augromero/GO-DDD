using System;
using System.Collections.Generic;
using Go.Interfaces.Data;
using Go.Juegos.Data;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Go.Juegos.Tests.Data
{
    [TestClass]
    public class PiedraCoordenadaRepoUnitTest
    {
        private Mock<IPuntoRepo> _puntoRepo;
        private Mock<IJuegoRepo> _juegoRepo;
        private PiedraCoordenadaRepo _piedraCoordenadaRepo;
        private Guid _juegoGuid;

        [TestInitialize]
        public void Inicializar()
        {
            _puntoRepo = new Mock<IPuntoRepo>();
            _juegoRepo = new Mock<IJuegoRepo>();

            _piedraCoordenadaRepo = new PiedraCoordenadaRepo(_juegoRepo.Object, _puntoRepo.Object);

            _juegoGuid = new Guid();
        }

        [TestMethod]
        public void ObtenerPiedrasCoordenadasDelJuego_retornaListaPiedrasCoordenadas()
        {
            List<Piedra> piedrasRetornadas = new List<Piedra>
            {
                new Piedra(_juegoGuid, Color.Negro, "9X2Y2"),
                new Piedra(_juegoGuid, Color.Blanco, "9X7Y7")
            };
            _juegoRepo.Setup(metodo => metodo.ObtenerPiedrasJuego(_juegoGuid))
                      .Returns(piedrasRetornadas);

            List<string> IdsPuntos = new List<string> { "9X2Y2", "9X7Y7" };
            List<Punto> puntosRetornados = new List<Punto>
            {
                new Punto(Tablero.nueveXnueve, 2, 2),
                new Punto(Tablero.nueveXnueve, 7, 7)
            };
            _puntoRepo.Setup(metodo => metodo.ObtenerPuntosPorIds(IdsPuntos))
                      .Returns(puntosRetornados);

            List<PiedraCoordenada> piedrasCoordenadas = _piedraCoordenadaRepo.ObtenerPiedrasCoordenadasDelJuego(_juegoGuid);

            Assert.AreEqual(2, piedrasCoordenadas.Count);
        }
    }
}
