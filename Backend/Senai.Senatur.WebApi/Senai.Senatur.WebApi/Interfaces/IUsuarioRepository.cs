using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IUsuarioRepository
    {

        IEnumerable<Usuarios> ListarTodos();
        Usuarios ListarPorId(int id);
        Usuarios ListarPorEmailSenha(string senha, string email);

        void Cadastrar(Usuarios CadastrarUsuario);
        void Atualizar(int id, Usuarios usuarioAtualizado);
        void Deletar(int id);

    }
}
