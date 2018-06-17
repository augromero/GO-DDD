using System;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Juegos.Tests.Modelos
{
    [TestClass]
    public class PiedraConexionUnitTest
    {

        [TestMethod]
        public void PiedraConexion_CreaUnaConexionEntreDosPiedrasDelJuego()
        {
            PiedraConexion piedraConexion = new PiedraConexion("9X2Y2", "9X2Y1", Color.Negro, TipoConexionPiedra.Amiga);

            Assert.AreEqual(Color.Negro, piedraConexion.ColorPiedra);
            Assert.AreEqual("9X2Y2", piedraConexion.PuntoPiedraPrincipal);
            Assert.AreEqual("9X2Y1", piedraConexion.PuntoPiedraConectada);
            Assert.AreEqual(TipoConexionPiedra.Amiga, piedraConexion.TipoConexion);
        
        }
    }
}
