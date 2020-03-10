using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }
    }
}

//Listar todos os usuários mostrando o título do tipo de usuário;
//Login - Buscar um usuário por e-mail e senha e gerar Token;
//Listar todos os Pacotes;
//Buscar um pacote por id;
//Cadastrar um Pacote;
//Alterar um Pacote(apenas um campo ou todos).