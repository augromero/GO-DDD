using System;
using System.Collections.Generic;
using Go.Juegos.Modelos.Enumerables;

namespace Go.Juegos.Modelos
{
    public class Juego
    {
        private Juego()
        {
        }

        public Guid Guid { get; private set; }
        public Tablero Tablero { get; private set; }
        public Color ColorActivo { get; private set; }
        public int TurnoActivo { get; private set; }

        public IEnumerable<Piedra> Piedras { get; private set; }
    }
}
