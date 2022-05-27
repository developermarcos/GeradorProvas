using System;
using System.Collections.Generic;
using Dominio.GeradorProvas;
using Dominio.GeradorProvas.ModuloMateria;
using Dominio.GeradorProvas.Compartilhado;
using System.Data.SqlClient;
using Infra.GeradorProvas.Db.ModuloMateira;
using Dominio.GeradorProvas.ModuloQuestao;
using Infra.GeradorProvas.Db.ModuloQuestao;

namespace Apresentacao.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Alternativa> alternativas = new List<Alternativa>();
            Alternativa alternativa1 = new Alternativa
            {
                Descricao = "inserção alternativa 1",
                EstaCorreta = false
            };
            alternativas.Add(alternativa1);
            Alternativa alternativa2 = new Alternativa
            {
                Descricao = "inserção alternativa 2",
                EstaCorreta = true
            };
            alternativas.Add(alternativa2);

            Materia matematica = new Materia
            {
                Descricao = "Adição",
                Disciplina = DisciplinaEnum.Matemática,
                Serie = SerieEnum.Primeira
            };
            Questao novaQuestao = new Questao
            {
                Alternativas = alternativas,
                Materia = matematica,
                Pergunta = "Pergunta teste inserção"
            };

            IRepositorioQuestao repositorioQuestao = new RepositorioQuestao();
            var questao = repositorioQuestao.SelecionarTodos();
            repositorioQuestao.Inserir(novaQuestao);

            repositorioQuestao.Excluir(novaQuestao);
            System.Console.ReadKey();
        }

    }
}
