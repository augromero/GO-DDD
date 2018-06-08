using System;
using System.Linq;
using Go.Interfaces.Data;
using Go.Juegos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Go.Juegos.Data
{
    public class JuegoRepo : IJuegoRepo
    {
        private JuegoContexto _contexto;
        public JuegoRepo(JuegoContexto contexto)
        {
            _contexto = contexto;
        }

        public Guid Guardar(Juego juego)
        {
            _contexto.Add(juego);
            _contexto.SaveChanges();

            return juego.Guid;

        }

        public Juego ObtenerJuego(Guid juegoGuid)
        {
            return _contexto.Juegos
                     .Include(juego => juego.Piedras)
                     .Include(juego => juego.Movimientos)
                     .Include(juego => juego.Grupos)
                     .FirstOrDefault(juego => juego.Guid == juegoGuid);
        }

        public void GuardarCambios()
        {
            _contexto.SaveChanges();
        }
    }
}
