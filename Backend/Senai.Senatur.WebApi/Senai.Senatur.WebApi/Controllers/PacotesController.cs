using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

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

        /// <summary>
        /// Lista os pacotes
        /// </summary>
        [HttpGet]
        public IEnumerable<Pacotes> Get()
        {
            return _pacoteRepository.Listar();
        }

        /// <summary>
        /// Busca usuários por id
        /// </summary>
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

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            _pacoteRepository.Cadastrar(novoPacote);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um pacote
        /// </summary>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pacotes pacoteAtualizado)
        {
            _pacoteRepository.Atualizar(pacoteAtualizado);

            return StatusCode(204);
        }
    }
}