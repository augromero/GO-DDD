using System;
using System.Collections.Generic;
using System.Linq;
using Go.Juegos.Modelos.Enumerables;

namespace Go.Juegos.Modelos
{
    public class Grupo
    {
        private Grupo()
        {
        }

        public Grupo(Guid juegoGuid, Color color, List<string> puntosPiedras, List<string> puntosLibertades)
        {
            Guid = new Guid();
            JuegoGuid = juegoGuid;
            PuntosPiedras = puntosPiedras;
            PuntosLibertades = puntosLibertades;
        }

        public Guid Guid { get; private set; }
        public Guid JuegoGuid { get; private set; }
        public Color Color { get; private set; }

        private List<string> _puntosPiedras;
        public List<string> PuntosPiedras 
        {
            get => _puntosPiedras;
            private set => _puntosPiedras = value;
        }

        public string Piedras
        {
            get => String.Join(',', _puntosPiedras);
            private set => _puntosPiedras = value.Split(',').ToList();
        }


        private List<string> _puntosLibertades;
        public List<string> PuntosLibertades { 
            get => _puntosLibertades; 
            private set => _puntosLibertades = value; 
        }

        public string Libertades
        {
            get => String.Join(',', _puntosLibertades);
            private set => _puntosLibertades = value.Split(',').ToList();
        }
    }
}
