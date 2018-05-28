using System;
using System.Collections.Generic;
using Go.Juegos.Modelos.Enumerables;
using Go.Juegos.Modelos.Puntos;

namespace Go.Juegos.Modelos
{
    public static class PiedraValidador
    {       

        public static void LanzaExcepcionSiPuntoEstaOcupado(string puntoId, List<string> puntosOcupados)
        {
            if (puntosOcupados.Contains(puntoId))
                throw new PuntoOcupadoException("Ocupado.");
        }

        public static void LanzaExcepcionSiPuntoEsInexistente(string puntoId, Tablero tablero)
        {
            if (PuntosTablero.ExistePuntoIdEnTablero(puntoId, tablero) is false)
                throw new PuntoInexistenteException("Punto inexistente.");
        }
    }
}
