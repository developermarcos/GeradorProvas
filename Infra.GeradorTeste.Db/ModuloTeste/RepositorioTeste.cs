
using Dominio.GeradorProvas;
using Dominio.GeradorProvas.ModuloQuestao;
using Dominio.GeradorProvas.ModuloTeste;
using FluentValidation;
using FluentValidation.Results;
using Infra.GeradorProvas.Db.Compartilhado;
using Infra.GeradorProvas.Db.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Infra.GeradorProvas.Db.ModuloTeste
{
    public class RepositorioTeste : RepositorioBase<Teste>, IRepositorioTeste
    {
        #region ScriptsSQL
        protected override string SqlSelectAll =>
            @"SELECT 
	                TESTE.NUMERO,
	                TESTE.TITULO,
	                TESTE.DISCIPLINA_NUMERO,
	                TESTE.SERIE_NUMERO,
	                TESTE.QUANTIDADE_QUESTOES

                FROM TBTESTE AS TESTE";

        protected override string SqlInsert =>
            @"INSERT INTO TBTESTE
                (
	                TITULO,
	                DISCIPLINA_NUMERO,
	                SERIE_NUMERO,
	                QUANTIDADE_QUESTOES
                )
                VALUES
                (
	                @TITULO,
	                @DISCIPLINA_NUMERO,
	                @SERIE_NUMERO,
	                @QUANTIDADE_QUESTOES
                );

                SELECT SCOPE_IDENTITY();";

        protected override string SqlDelete =>
            @"  DELETE TBTESTEQUESTAO
                    WHERE TESTE_NUMERO = @NUMERO

                DELETE TBTESTE
                    WHERE NUMERO = @NUMERO";

        protected override string SqlEdit =>
            @"UPDATE TBTESTE
                    SET 
                        TITULO = @TITULO
                    WHERE
	                    NUMERO = @NUMERO;";

        protected override string SqlSelectBy =>
            @"SELECT 
	            TESTE.NUMERO,
	            TESTE.TITULO,
	            TESTE.DISCIPLINA_NUMERO,
	            TESTE.SERIE_NUMERO,
	            TESTE.QUANTIDADE_QUESTOES

                FROM TBTESTE AS TESTE

                WHERE TESTE.NUMERO = @NUMERO";
        #endregion

        #region ScriptsSQL Teste questões
        private protected string sqlSelectAllQuestoesNumeroPorTeste =
            @"SELECT 
	                VINCULO.QUESTAO_NUMERO as NUMERO

                FROM TBTESTE AS TESTE

                LEFT JOIN TBTESTEQUESTAO AS VINCULO

                ON TESTE.NUMERO = VINCULO.TESTE_NUMERO

                WHERE TESTE.NUMERO = @NUMERO";

        private readonly string SqlVerificaTituloJaCadastradoInserir =
            @"SELECT COUNT(1) FROM TBTESTE WHERE TITULO = @TITULO;";

        private readonly string SqlVerificaTituloJaCadastradoEditar =
            @"SELECT COUNT(1) FROM TBTESTE WHERE TITULO = @TITULO and NUMERO <> @NUMERO;";

        private readonly string sqlInserirVinculoQuestoes =
            @"INSERT INTO TBTESTEQUESTAO
                (
	                TESTE_NUMERO,
	                QUESTAO_NUMERO
                )
                VALUES
                (
	                @TESTE_NUMERO,
	                @QUESTAO_NUMERO
                );";
        #endregion

        #region Métodos sobrescritos
        public override List<Teste> SelecionarTodos()
        {
            var testes = base.SelecionarTodos();

            foreach(var item in testes)
            {
                var numeroQuestoes = SelecionaNumeroQuestoesPorTeste(item.Numero);

                item.Questoes = new List<Questao>();

                foreach(var numeroQuestao in numeroQuestoes)
                {
                    var questao = new RepositorioQuestao().SelecionarPorNumero(numeroQuestao);
                    item.Questoes.Add(questao);
                }
                
            }

            return testes;
        }

        public override Teste SelecionarPorNumero(int numero)
        {
            var teste = base.SelecionarPorNumero(numero);

            teste.Questoes = new List<Questao>();

            var numeroQuestoes = SelecionaNumeroQuestoesPorTeste(teste.Numero);

            foreach (var numeroQuestao in numeroQuestoes)
            {
                var questao = new RepositorioQuestao().SelecionarPorNumero(numeroQuestao);
                teste.Questoes.Add(questao);
            }
            
            return teste;
        }

        public override ValidationResult Inserir(Teste novoRegistro)
        {

            bool perguntaJaCadastrada = VerificaNomeJaCadastrado(novoRegistro, SqlVerificaTituloJaCadastradoInserir);

            if (perguntaJaCadastrada)
            {
                ValidationFailure perguntaRepetida = new ValidationFailure("", "Questão não cadastrada, pergunta ja foi utilizada em outra questão");

                ValidationResult validador = new ValidationResult();

                validador.Errors.Add(perguntaRepetida);

                return validador;
            }

            if (novoRegistro.Questoes.Count < 1)
            {
                ValidationFailure perguntaRepetida = new ValidationFailure("", "Nenhuma questão encontrada.");

                ValidationResult validador = new ValidationResult();

                validador.Errors.Add(perguntaRepetida);

                return validador;
            }

            var resultado = base.Inserir(novoRegistro);

            if(resultado.IsValid == true)
            {
                InserirVinculoAlternativas(novoRegistro.Numero, novoRegistro.Questoes);
            }

            return resultado;
        }

        public override ValidationResult Editar(Teste registro)
        {
            bool perguntaJaCadastrada = VerificaNomeJaCadastrado(registro, SqlVerificaTituloJaCadastradoEditar);

            if (perguntaJaCadastrada)
                return ValidaTesteCadastrada("Teste não editada, título ja foi utilizada em outro teste");


            return base.Editar(registro);
        }

        private void InserirVinculoAlternativas(int testeNumero, List<Questao> questoes)
        {
            SqlConnection conexaoComBanco = new SqlConnection(conexaoBanco);
            conexaoComBanco.Open();

            foreach(var item in questoes)
            {
                SqlCommand comandoInsercao = new SqlCommand(sqlInserirVinculoQuestoes, conexaoComBanco);

                comandoInsercao.Parameters.AddWithValue("QUESTAO_NUMERO", item.Numero);
                comandoInsercao.Parameters.AddWithValue("TESTE_NUMERO", testeNumero);

                var id = comandoInsercao.ExecuteNonQuery();
            }

            conexaoComBanco.Close();
        }

        private bool VerificaNomeJaCadastrado(Teste novoRegistro, string consulta)
        {
            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = conexaoBanco;
            conexaoComBanco.Open();


            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            comandoSelecao.CommandText = consulta;

            comandoSelecao.Parameters.AddWithValue("TITULO", novoRegistro.Titulo);
            comandoSelecao.Parameters.AddWithValue("NUMERO", novoRegistro.Numero);

            int numero = Convert.ToInt32(comandoSelecao.ExecuteScalar());

            conexaoComBanco.Close();

            if(numero > 0)
                return true;

            return false;
        }

        public override void ConfigurarParametrosRegistro(Teste registro, SqlCommand comandoSql)
        {
            comandoSql.Parameters.AddWithValue("NUMERO", registro.Numero);
            comandoSql.Parameters.AddWithValue("TITULO", registro.Titulo);
            comandoSql.Parameters.AddWithValue("DISCIPLINA_NUMERO", registro.Disciplina);
            comandoSql.Parameters.AddWithValue("SERIE_NUMERO", registro.Serie);
            comandoSql.Parameters.AddWithValue("QUANTIDADE_QUESTOES", registro.quantidadeQuestoes);
        }

        public override Teste ConverterRegistro(SqlDataReader leitorContato)
        {
            int numero = Convert.ToInt32(leitorContato["NUMERO"]);
            string titulo = Convert.ToString(leitorContato["TITULO"]);
            int quantidadeQuestoes = Convert.ToInt32(leitorContato["QUANTIDADE_QUESTOES"]);
            DisciplinaEnum disciplina = (DisciplinaEnum)Convert.ToInt32(leitorContato["DISCIPLINA_NUMERO"]);
            SerieEnum serie = (SerieEnum)Convert.ToInt32(leitorContato["SERIE_NUMERO"]);

            var teste = new Teste
            {
                Numero = numero,
                Titulo = titulo,
                quantidadeQuestoes = quantidadeQuestoes,
                Disciplina = disciplina,
                Serie = serie
            };

            return teste;
        }

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidadorTeste();
        }
        #endregion

        #region Métodos Próprios
        private List<int> SelecionaNumeroQuestoesPorTeste(int questaoNumero)
        {

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = conexaoBanco;
            conexaoComBanco.Open();


            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            comandoSelecao.CommandText = sqlSelectAllQuestoesNumeroPorTeste;

            comandoSelecao.Parameters.AddWithValue("NUMERO", questaoNumero);

            SqlDataReader leitorRegistros = comandoSelecao.ExecuteReader();

            var questoesNumeros = new List<int>();

            while (leitorRegistros.Read())
            {
                int numero = Convert.ToInt32(leitorRegistros["NUMERO"]);
                questoesNumeros.Add(numero);
            }


            conexaoComBanco.Close();

            return questoesNumeros;
        }

        private ValidationResult ValidaTesteCadastrada(string menssage)
        {
            ValidationFailure perguntaRepetida = new ValidationFailure("", menssage);

            ValidationResult validador = new ValidationResult();

            validador.Errors.Add(perguntaRepetida);

            return validador;
        }

        #endregion
    }
}
