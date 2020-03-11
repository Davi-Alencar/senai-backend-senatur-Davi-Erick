using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class PacotesController : ControllerBase
    {
        private IPacoteRepository _pacoteRepository;

        public PacotesController()
        {
            _pacoteRepository = new PacoteRepository();
        }

        [HttpGet]
        public IEnumerable<Pacotes> Get()
        {
            return _pacoteRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Pacotes pacoteBuscado = _pacoteRepository.BuscarPorId(id);

            if(pacoteBuscado == null)
            {
                return NotFound("Pacote não ncontrado.");
            }

            return Ok(pacoteBuscado);
        }

        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            _pacoteRepository.Cadastrar(novoPacote);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Pacotes pacoteAtualizado)
        {
            // Faz a chamada para o método
            _pacoteRepository.Atualizar(id, pacoteAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }
    }
}