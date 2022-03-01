using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoveClient.API.Data;
using LoveClient.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoveClient.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]{
         new Evento(){
            EventoId = 1,
            Titulo = "Angular 11 e .NET 5",
            Local = "BH",
            Lote = "1º Lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
            ImagemURL = "foto.png"
         },
         new Evento(){
            EventoId = 2,
            Titulo = "Angular 11 e suas novidades",
            Local = "BH",
            Lote = "2º Lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
            ImagemURL = "foto1.png"
         }
      };
        private readonly DataContext _context;
        public EventosController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "exemplo de Post";
        }
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"exemplo de Put com id = {id}";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"exemplo de Delete com id = {id}";
        }
    }
}