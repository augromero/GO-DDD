using System;
using System.Collections.Generic;
using System.Linq;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;

namespace Go.Juegos.Servicios
{
    public class GrupoCreador
    {
        private Juego _juego;
        public GrupoCreador(Juego juego)
        {
            _juego = juego;
        }

        public List<Grupo> AgruparPiedras(Punto punto)
        {
            List<Grupo> gruposNuevos = new List<Grupo>();
            List<string> puntosPiedras = new List<string> { punto.Id };

            //List<Grupo> gruposActuales = _juego.ObtenerGruposPorColor(_juego.ColorActivo);

            //List<string> libertadesGrupo = ObtenerLibertadesDelGrupo(gruposActuales);



            gruposNuevos.Add(new Grupo(_juego.Guid, _juego.ColorActivo, puntosPiedras, punto.ObtenerConexiones()));

            return gruposNuevos;
        }

        private List<string> ObtenerLibertadesDelGrupo(List<Grupo> grupos)
        {
            List<string> libertades = new List<string>();
            grupos.ForEach(grupo => libertades.AddRange(grupo.PuntosLibertades));

            return libertades.Distinct().ToList();
        }
    }
}
