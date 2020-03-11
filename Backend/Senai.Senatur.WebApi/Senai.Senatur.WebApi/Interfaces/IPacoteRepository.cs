using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacoteRepository
    {

        IEnumerable<Pacotes> ListarTodos();
        IEnumerable<Pacotes> ListarAtivos();
        IEnumerable<Pacotes> ListarInativos();
        IEnumerable<Pacotes> ListarOrdenadoPorPreco();
        Pacotes ListarPorId(int id);


        void Atualizar(int id, Pacotes pacote);
        void Cadastar(Pacotes pacote);
        void Deletar(int id);
    }
}
