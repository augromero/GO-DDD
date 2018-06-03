using System;
namespace Go.Juegos.Modelos.Enumerables
{
    public enum Tablero
    {
        nueveXnueve = 9,
        onceXonce = 11,
        treceXtrece = 13,
        quinceXquince = 15,
        diecisieteXdiecisiete = 17,
        diecinueveXdiecinueve = 19
    }

    public static class TableroValidador
    {
        public static bool EsTamañoCorrecto(int tamañoTablero)
        {
            return Enum.IsDefined(typeof(Tablero), tamañoTablero);
        }
    }
}
