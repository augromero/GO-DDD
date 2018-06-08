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
            Grupos = new List<Grupo>();

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
        public ICollection<Grupo> Grupos { get; private set; }

        public void AdicionarPiedra(Piedra piedra)
        {
            Piedras.Add(piedra);
        }

        public void AdicionarMovimiento(Movimiento movimiento)
        {
            Movimientos.Add(movimiento);
        }

        public void CambioDeTurno()
        {
            TurnoActivo++;
            ColorActivo = CambiarColor();
        }

        private Color CambiarColor()
        {
            if (ColorActivo == Color.Negro)
                return Color.Blanco;
            else
                return Color.Negro;
        }

        public List<string> ObtenerPuntosOcupados()
        {
            
            return Piedras.Select(piedra => piedra.PuntoId).ToList();
        }

        public List<Piedra> ObtenerPiedrasPorColor(Color color)
        {
            return Piedras.Where(piedra => piedra.Color == color)
                   .ToList();
        }

        public List<Grupo> ObtenerGruposPorColor(Color color)
        {
            return Grupos.Where(grupo => grupo.Color == color)
                         .ToList();
        }

        public void ActualizarGrupos(List<Grupo> nuevosGrupos)
        {
            Grupos = nuevosGrupos;
        }
    }
}
