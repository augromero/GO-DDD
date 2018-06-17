using System;
using System.Collections.Generic;
using Go.Juegos.Modelos;
using System.Linq;
using Go.Juegos.Modelos.Enumerables;

namespace Go.Juegos.Servicios
{
    public class PiedraConector
    {
        public List<PiedraConexion> RelacionarPiedrasJuego(List<PiedraCoordenada> piedrasJuego)
        {
            List<PiedraConexion> conexiones =
                (from principal in piedrasJuego
                 from conectado in piedrasJuego
                 where Math.Abs(principal.X - conectado.X) + Math.Abs(principal.Y - conectado.Y) == 1
                 select
                 new PiedraConexion(principal.IdPunto, conectado.IdPunto, principal.Color,
                                    (principal.Color == conectado.Color) ? TipoConexionPiedra.Amiga : TipoConexionPiedra.Enemiga)
                ).ToList();

            return conexiones;
        }
    }
}
