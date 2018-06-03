using System.Collections.Generic;
using System.Linq;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class PuntoUnitTest
    {
        [TestMethod]
        public void CreaPuntoAPartirDeTableroYCoordenadas()
        {
            Punto punto = new Punto(Tablero.nueveXnueve, 1, 1);

            Assert.AreEqual("9X1Y1", punto.Id);
        }

        [TestMethod]
        public void CalcularPuntoDerecha_RetornaPuntoMas1EnX()
        {
            Punto punto = new Punto(Tablero.nueveXnueve, 1, 1);

            Assert.AreEqual("9X2Y1", punto.PuntoDerechaId);
        }

        [TestMethod]
        public void CalcularPuntoDerecha_EnBordeDerecho_RetornaNull()
        {
            Punto punto = new Punto(Tablero.nueveXnueve, 9, 1);

            Assert.IsNull(punto.PuntoDerechaId);
        }

        [TestMethod]
        public void CalcularPuntoIzquierda_ReturnaPuntoMenos1EnX()
        {
            Punto punto = new Punto(Tablero.nueveXnueve, 2, 1);

            Assert.AreEqual("9X1Y1", punto.PuntoIzquierdaId);
        }

        [TestMethod]
        public void CalcularPuntoIzquierda_EnBordeIzquierdo_RetornaNull()
        {
            Punto punto = new Punto(Tablero.nueveXnueve, 1, 1);

            Assert.IsNull(punto.PuntoIzquierdaId);
        }

        [TestMethod]
        public void CalcularPuntoArriba_RetornaPuntoMas1EnY()
        {
            Punto punto = new Punto(Tablero.nueveXnueve, 1, 1);

            Assert.AreEqual("9X1Y2", punto.PuntoArribaId);
        }

        [TestMethod]
        public void CalcularPuntoArriba_EnBordeSuperior_RetornaNull()
        {
            Punto punto = new Punto(Tablero.nueveXnueve, 1, 9);

            Assert.IsNull(punto.PuntoArribaId);
        }

        [TestMethod]
        public void CalcularPuntoAbajo_retornaPuntoMenos1EnY()
        {
            Punto punto = new Punto(Tablero.nueveXnueve, 1, 2);

            Assert.AreEqual("9X1Y1", punto.PuntoAbajoId);
        }

        [TestMethod]
        public void CalcularPuntoAbajo_EnBordeInferior_retornaNull()
        {
            Punto punto = new Punto(Tablero.nueveXnueve, 1, 1);

            Assert.IsNull(punto.PuntoAbajoId);
        }

        [TestMethod]
        public void CrearPuntosTablero_cuandoEs9x9_Retorna81Puntos()
        {
            List<Punto> puntosTablero9x9 = PuntosTablero.CrearPuntosTablero(Tablero.nueveXnueve);

            Assert.AreEqual(81, puntosTablero9x9.Count);
            Assert.AreEqual(9, puntosTablero9x9.Max(punto => punto.X));
            Assert.AreEqual(9, puntosTablero9x9.Max(punto => punto.Y));
        }

    }
}
