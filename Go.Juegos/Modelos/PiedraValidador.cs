using System.Collections.Generic;
using Fenix.Excepciones;

namespace Go.Juegos.Modelos
{
    public static class PiedraValidador
    {

        public static void LanzaExcepcionSiPuntoEstaOcupado(string puntoId, List<string> puntosOcupados)
        {
            if (puntosOcupados.Contains(puntoId))
                throw new FenixExceptionConflict("Ya existe una piedra en ese punto");
        }


    }
}
