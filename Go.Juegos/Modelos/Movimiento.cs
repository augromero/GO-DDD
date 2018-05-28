using System;
using Go.Juegos.Modelos.Enumerables;

namespace Go.Juegos.Modelos
{
    public class Movimiento
    {
        public Movimiento(Guid juegoGuid, Color color, string puntoId, int turno)
        {
            Guid = new Guid();
            JuegoGuid = juegoGuid;
            Color = color;
            PuntoId = puntoId;
            Turno = turno;
            FechaRegistro = DateTime.Now;
        }

        private Movimiento()
        {
        }

        public Guid Guid { get; private set; }
        public Guid JuegoGuid { get; private set; }
        public Color Color { get; private set; }
        public string PuntoId { get; private set; }
        public int Turno { get; private set; }
        public DateTime FechaRegistro { get; private set; }
    }
}
