using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

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
        
        /// <summary>
        /// Busca usuário c/ tipo
        /// </summary>
        [HttpGet]
        public IActionResult BuscarComTipo()
        {
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Realiza e valida o login o login
        /// </summary>
        [HttpPost]
        public IActionResult Post(Usuarios login)
        {
            Usuarios usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim("Claim personalizada", "Valor teste")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senatur-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Senatur.WebApi",                
                audience: "Senatur.WebApi",              
                claims: claims,                         
                expires: DateTime.Now.AddMinutes(30),   
                signingCredentials: creds               
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}

//Listar todos os usuários mostrando o título do tipo de usuário;
//Login - Buscar um usuário por e-mail e senha e gerar Token;
//Listar todos os Pacotes;
//Buscar um pacote por id;
//Cadastrar um Pacote;
//Alterar um Pacote(apenas um campo ou todos).