﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go.Interfaces.Aplicacion;
using Go.Juegos.Modelos;
using Go.Juegos.Modelos.Enumerables;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Go.Juegos.API.Controllers
{
    
    [Route("api/[controller]")]
    public class JuegoController : Controller
    {
        private readonly IJuegoIniciador _juegoIniciador;

        public JuegoController(IJuegoIniciador juegoIniciador)
        {
            _juegoIniciador = juegoIniciador;
        }

        [HttpPost]
        public Juego Post([FromBody]int tamañoTablero)
        {
            
            Juego juego = _juegoIniciador.IniciarJuego(tamañoTablero);

            return juego;
        }

       
    }
}
