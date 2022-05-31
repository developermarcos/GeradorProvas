using System;
using System.Collections.Generic;
using Dominio.GeradorProvas;
using Dominio.GeradorProvas.ModuloMateria;
using Dominio.GeradorProvas.Compartilhado;
using System.Data.SqlClient;
using Infra.GeradorProvas.Db.ModuloMateira;
using Dominio.GeradorProvas.ModuloQuestao;
using Infra.GeradorProvas.Db.ModuloQuestao;
using Infra.GeradorProvas.Db.ModuloTeste;
using Dominio.GeradorProvas.ModuloTeste;

namespace Apresentacao.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepositorioQuestao repositorioQuestao = new RepositorioQuestao();
            var questao1 = repositorioQuestao.SelecionarPorNumero(1);
            var questao2 = repositorioQuestao.SelecionarPorNumero(2);
            var teste = new Teste
            {
                Disciplina = DisciplinaEnum.Matemática,
                Serie = SerieEnum.Primeira,
                quantidadeQuestoes = 2,
                Titulo = "teste inserção",
                Questoes = new List<Questao>(),
            };
            teste.Questoes.Add(questao1);
            teste.Questoes.Add(questao2);

            IRepositorioTeste repositorioTeste = new RepositorioTeste();
            //var testes = repositorioTeste.SelecionarTodos();

            //var teste = repositorioTeste.SelecionarPorNumero(1);

            var resultInsert = repositorioTeste.Inserir(teste);
            //repositorioTeste.Excluir(teste);
            teste.Titulo = "Teste inserção alterado";
            var resultEdit = repositorioTeste.Editar(teste);
            System.Console.ReadKey();
        }

    }
}
