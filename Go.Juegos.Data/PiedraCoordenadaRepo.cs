using System;
using System.Collections.Generic;
using System.Linq;
using Go.Interfaces.Data;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Puntos;

namespace Go.Juegos.Data
{
    public class PiedraCoordenadaRepo
    {
        private IJuegoRepo _juegoRepo;
        private IPuntoRepo _puntoRepo;

        public PiedraCoordenadaRepo()
        {
        }

        public PiedraCoordenadaRepo(IJuegoRepo juegoRepo, IPuntoRepo puntoRepo)
        {
            _juegoRepo = juegoRepo;
            _puntoRepo = puntoRepo;
        }

        public List<PiedraCoordenada> ObtenerPiedrasCoordenadasDelJuego(Guid juegoGuid)
        {
            List<Piedra> piedras =_juegoRepo.ObtenerPiedrasJuego(juegoGuid);
            List<String> idsPuntos = piedras.Select(piedra => piedra.PuntoId).ToList();

            List<Punto> puntos = _puntoRepo.ObtenerPuntosPorIds(idsPuntos);

            List<PiedraCoordenada> piedrasCoordenadas = 
                (from pi in piedras
                 join pu in puntos on pi.PuntoId equals pu.Id
                 select new PiedraCoordenada(pi, pu)).ToList();

            return piedrasCoordenadas;

        }
    }
}
