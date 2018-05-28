using System;
using System.Collections.Generic;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class PiedraValidadorUnitTest
    {
        [TestInitialize]
        public void Inicializar()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(PuntoOcupadoException), "El punto está ocupado.")]
        public void PuntoOcupado_cuandoNoEstaDisponible_LanzaExcepcion()
        {
            string puntoId = "9X1Y1";
            List<string> puntosOcupados = new List<string> { "9X1Y1", "9X2Y1" };


            PiedraValidador.LanzaExcepcionSiPuntoEstaOcupado(puntoId, puntosOcupados);
        }

        [TestMethod]
        [ExpectedException(typeof(PuntoInexistenteException), "El punto no está en el tablero")]
        public void PuntoInexistente_cuandoNoExiste_LanzaExcepcion()
        {
            string puntoId = "13X1Y1";
            Tablero tablero = Tablero.nueveXnueve;

            PiedraValidador.LanzaExcepcionSiPuntoEsInexistente(puntoId, tablero);
        }
    }
}
