using System;
using System.Collections.Generic;
using System.Linq;
using Go.Juegos.Modelos.Enumerables;

namespace Go.Juegos.Modelos
{
    public class Juego
    {
        
        public Juego(Tablero tablero)
        {
            Guid = new Guid(); 
            Tablero = tablero;
            ColorActivo = Color.Negro;
            TurnoActivo = 1;
            Piedras = new List<Piedra>();
            Movimientos = new List<Movimiento>();

        }

        private Juego()
        {
        }

        public Guid Guid { get; private set; }
        public Tablero Tablero { get; private set; }
        public Color ColorActivo { get; private set; }
        public int TurnoActivo { get; private set; }

        public ICollection<Piedra> Piedras { get; private set; }
        public ICollection<Movimiento> Movimientos { get; private set; }

        public void PonerPiedra(string puntoId)
        {
            PiedraValidador.LanzaExcepcionSiPuntoEstaOcupado(puntoId, ObtenerPuntosOcupados());

            Piedras.Add(new Piedra(Guid, ColorActivo, puntoId));
            Movimientos.Add(new Movimiento(Guid, ColorActivo, puntoId, TurnoActivo));

            CambioDeTurno();

        }

        private void CambioDeTurno()
        {
            TurnoActivo++;
            ColorActivo = CambiarColor();
        }

        public List<string> ObtenerPuntosOcupados()
        {
            
            return Piedras.Select(piedra => piedra.PuntoId).ToList();
        }

        private Color CambiarColor()
        {
            if (ColorActivo == Color.Negro)
                return Color.Blanco;
            else
                return Color.Negro;
        }
    }
}
