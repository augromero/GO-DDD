using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go.Aplicacion.DTO;
using Go.Interfaces.Aplicacion;
using Go.Juegos.Modelos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Go.Juegos.API.Controllers
{
    
    public class PartidaController : Controller
    {
        private readonly IPartida _partida;

        public PartidaController(IPartida partida)
        {
            _partida = partida;
        }
        [Route("api/Partida/JugarPiedra")]
        [HttpPost]
        public Juego JugarPiedra([FromBody]PiedraSoltada piedraSoltada)
        {
            return _partida.JugarPiedra(piedraSoltada.JuegoGuid, piedraSoltada.PuntoId);
        }

       
    }
}
