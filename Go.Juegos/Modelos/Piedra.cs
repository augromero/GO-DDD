﻿using System;
using Go.Juegos.Modelos.Enumerables;

namespace Go.Juegos.Modelos
{
    public class Piedra
    {
        

        public Piedra(Guid juegoGuid, Color color, string puntoId)
        {
            Guid = new Guid();
            JuegoGuid = juegoGuid;
            Color = color;
            PuntoId = puntoId;
        }

        private Piedra()
        {
        }

        public Guid Guid { get; private set; }
        public Guid JuegoGuid { get; private set; }
        public Color Color { get; private set; }
        public string PuntoId { get; private set; }
    }
}
