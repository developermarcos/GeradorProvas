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
            //Materia novaMateria = new Materia(DisciplinaEnum.Matemática, SerieEnum.Segunda, "teste");
            //novaMateria.Numero = 5;
            //IRepositorioMateria repositorioMateria = new RepositorioMateria();
            //var teste = repositorioMateria.SelecionarTodos();
            //var registroPorId = repositorioMateria.SelecionarPorNumero(2);
            //repositorioMateria.Inserir(novaMateria);

            //novaMateria.Descricao = "Subtração alterada";
            //repositorioMateria.Editar(novaMateria);

            //novaMateria.Numero = 3;

            //repositorioMateria.Excluir(novaMateria);
            //System.Console.ReadKey();

            IRepositorioQuestao repositorioQuestao = new RepositorioQuestao();
            var questao = repositorioQuestao.SelecionarTodos();
            System.Console.ReadKey();
        }

    }
}
