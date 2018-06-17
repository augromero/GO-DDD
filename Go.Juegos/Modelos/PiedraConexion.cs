using System;
using Go.Juegos.Modelos.Enumerables;

namespace Go.Juegos.Modelos
{
    public class PiedraConexion
    {
        public PiedraConexion(string puntoPiedraPrincipal, string puntoPiedraConectada, Color color, TipoConexionPiedra tipoConexion)
        {
            PuntoPiedraPrincipal = puntoPiedraPrincipal;
            PuntoPiedraConectada = puntoPiedraConectada;
            ColorPiedra = color;
            TipoConexion = tipoConexion;
        }


        public string PuntoPiedraPrincipal { get; private set; }
        public string PuntoPiedraConectada { get; private set; }
        public Color ColorPiedra { get; private set; }
        public TipoConexionPiedra TipoConexion { get; private set; }
    }
}
