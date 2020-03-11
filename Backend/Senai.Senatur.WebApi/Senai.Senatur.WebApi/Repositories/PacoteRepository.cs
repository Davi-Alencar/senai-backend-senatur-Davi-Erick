using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        private SenaturContext ctx = new SenaturContext();

        public void Atualizar(Pacotes pacoteAtualizado)
        {
            var pacote = ctx.Pacotes.First(P => P.IdPacote == pacoteAtualizado.IdPacote);
            pacote.NomePacote = pacoteAtualizado.NomePacote;
            pacote.Descricao = pacoteAtualizado.Descricao;
            pacote.DataIda = pacoteAtualizado.DataIda;
            pacote.DataVolta = pacoteAtualizado.DataVolta;
            pacote.NomeCidade = pacoteAtualizado.NomeCidade;
            pacote.Ativo = pacoteAtualizado.Ativo;

            ctx.SaveChanges();
        }


        public Pacotes BuscarPorId(int id)
        {
            return ctx.Pacotes.FirstOrDefault(p => p.IdPacote == id);
        }
        public void Cadastrar(Pacotes pacotesNovo)
        {
            ctx.Pacotes.Add(pacotesNovo);
            ctx.SaveChanges();
        }
        public List<Pacotes> Listar()
        {
            return ctx.Pacotes.ToList();
        }
    }
}

