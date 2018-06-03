using System;
using Go.Interfaces.Repositorios;
using Go.Juegos.Modelos;

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
            return _contexto.Find<Juego>(juegoGuid);
        }

        public void GuardarCambios()
        {
            _contexto.SaveChanges();
        }
    }
}
