using Dominio.GeradorProvas.ModuloQuestao;
using Dominio.GeradorProvas.ModuloMateria;
using Dominio.GeradorProvas;
using FluentValidation;
using FluentValidation.Results;
using Infra.GeradorProvas.Db.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infra.GeradorProvas.Db.ModuloQuestao
{
    public class RepositorioQuestao : RepositorioBase<Questao>, IRepositorioQuestao
    {
        #region Scripts SQL
        protected override string SqlSelectAll =>
            @"SELECT 
                QUESTAO.NUMERO AS NUMERO,
	            QUESTAO.PERGUNTA AS PERGUNTA,
	            MATERIA.NUMERO AS MATERIA_NUMERO,
	            MATERIA.DESCRICAO AS MATERIA_DESCRICAO,
	            MATERIA.DISCIPLINA AS MATERIA_DISCIPLINA,
	            MATERIA.SERIE AS MATERIA_SERIE

            FROM TBQUESTAO AS QUESTAO

            LEFT JOIN TBMATERIA AS MATERIA

            ON QUESTAO.MATERIA_NUMERO = MATERIA.NUMERO";

        protected override string SqlInsert =>
            @"INSERT INTO TBQUESTAO
                (
	                PERGUNTA,
	                MATERIA_NUMERO
                )
                VALUES
                (
                    @PERGUNTA,
                    @MATERIA_NUMERO
                );

                SELECT SCOPE_IDENTITY();";

        protected override string SqlDelete =>
            @"DELETE FROM TBQUESTAO
                
                WHERE NUMERO = @NUMERO";

        protected override string SqlEdit =>
            @"UPDATE TBQUESTAO
                SET 
                    PERGUNTA = @PERGUNTA,
                    MATERIA_NUMERO = @MATERIA_NUMERO
                WHERE
	                NUMERO = @NUMERO;";

        protected override string SqlSelectBy =>
            @"SELECT 
                    Q.NUMERO AS NUMERO,
	                Q.PERGUNTA AS PERGUNTA,
	                M.NUMERO AS MATERIA_NUMERO,
	                M.DESCRICAO AS MATERIA_DESCRICAO,
	                M.DISCIPLINA AS MATERIA_DISCIPLINA,
	                M.SERIE AS MATERIA_SERIE

                FROM TBQUESTAO AS Q

                LEFT JOIN TBMATERIA AS M

                ON Q.MATERIA_NUMERO = M.NUMERO

	            WHERE Q.NUMERO = @NUMERO";

        private readonly string VerificaNomeJaCadastrado =
            @"SELECT COUNT(1) FROM TBQUESTAO WHERE PERGUNTA = @PERGUNTA";
        #endregion

        #region Scripts SQL Alternativas
        private readonly string sqlSelectAllAlternativa =
            @"SELECT 
	            [NUMERO],
	            [DESCRICAO],
	            [CORRETA],
	            [QUESTAO_NUMERO]

            FROM [TBALTERNATIVA]

            WHERE QUESTAO_NUMERO = @NUMERO";

        private readonly string sqlInsertAlternativa =
            @"INSERT INTO [TBALTERNATIVA]
                (
	                [DESCRICAO],
	                [CORRETA],
	                [QUESTAO_NUMERO]
                )
                VALUES
                (
	                @DESCRICAO,
	                @CORRETA,
	                @QUESTAO_NUMERO
                );

                SELECT SCOPE_IDENTITY();";

        private readonly string sqlDeleteAlternativas =
            @"DELETE FROM TBALTERNATIVA
                
                WHERE QUESTAO_NUMERO = @QUESTAO_NUMERO";

        #endregion

        #region Métodos Sobrescritos
        public override List<Questao> SelecionarTodos()
        {
            var questoes = base.SelecionarTodos();
            
            foreach(var item in questoes)
            {
                SelecionarAlternativaPorQuestao(item);
            }

            return questoes;
        }

        public override Questao SelecionarPorNumero(int numero)
        {
            var questao = base.SelecionarPorNumero(numero);

            SelecionarAlternativaPorQuestao(questao);
            return questao;
        }

        public override ValidationResult Inserir(Questao novoRegistro)
        {
            var resultado = base.Inserir(novoRegistro);

            if(resultado.IsValid == true)
            {
                InserirAlternativas(novoRegistro.Numero, novoRegistro.Alternativas);
            }

            return resultado;
        }

        public override ValidationResult Editar(Questao registro)
        {
            var validador = base.Editar(registro);

            if(validador.IsValid == true)
                alterarAlternarivas(registro);            

            return validador;
        }

        

        public override ValidationResult Excluir(Questao registro)
        {
            ExcluirAlternativas(registro.Numero);
            return base.Excluir(registro);
        }

        public override void ConfigurarParametrosRegistro(Questao registro, SqlCommand comandoSql)
        {
            comandoSql.Parameters.AddWithValue("NUMERO", registro.Numero);
            comandoSql.Parameters.AddWithValue("PERGUNTA", registro.Pergunta);
            comandoSql.Parameters.AddWithValue("MATERIA_NUMERO", registro.Materia.Numero);
        }

        public override Questao ConverterRegistro(SqlDataReader leitorQuestao)
        {
            int numero = Convert.ToInt32(leitorQuestao["NUMERO"]);
            string descricao = Convert.ToString(leitorQuestao["PERGUNTA"]);
            int materia_numero = Convert.ToInt32(leitorQuestao["MATERIA_NUMERO"]);
            string materia_descricao = Convert.ToString(leitorQuestao["MATERIA_DESCRICAO"]);
            DisciplinaEnum materia_disciplina = (DisciplinaEnum)Convert.ToInt32(leitorQuestao["MATERIA_DISCIPLINA"]);
            SerieEnum materia_serie = (SerieEnum)Convert.ToInt32(leitorQuestao["MATERIA_SERIE"]);

            var Materia = new Materia
            {
                Numero = materia_numero,
                Descricao = materia_descricao,
                Disciplina = materia_disciplina,
                Serie = materia_serie
            };

            var Questao = new Questao
            {
                Numero = numero,
                Pergunta = descricao,
                Materia = Materia
            };

            return Questao;
        }

        public override AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();
        }

        #endregion

        #region CRUD Alternativas
        private void SelecionarAlternativaPorQuestao(Questao questao)
        {

            #region abrir a conexão com o banco de dados

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = conexaoBanco;
            conexaoComBanco.Open();

            #endregion

            #region  criar um comando 
            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            comandoSelecao.CommandText = sqlSelectAllAlternativa;

            comandoSelecao.Parameters.AddWithValue("NUMERO", questao.Numero);

            #endregion

            //executar o comando
            SqlDataReader leitoRegistro = comandoSelecao.ExecuteReader();

            while (leitoRegistro.Read())
            {
                var item = ConverterAlternativa(leitoRegistro);
                questao.Alternativas.Add(item);
            }

            //fechar a conexão
            conexaoComBanco.Close();
        }

        private ValidationResult InserirAlternativas(int questaoNumero, List<Alternativa> alternativas)
        {
            var validadorAlternativa = new ValidadorAlternativa();

            foreach(var item in alternativas)
            {
                var resultadoValidacao = validadorAlternativa.Validate(item);

                if (resultadoValidacao.IsValid == false)
                    return resultadoValidacao;
            }
                
            SqlConnection conexaoComBanco = new SqlConnection(conexaoBanco);

            conexaoComBanco.Open();

            foreach(var item in alternativas)
            {
                SqlCommand comandoInsercao = new SqlCommand(sqlInsertAlternativa, conexaoComBanco);

                ConfigurarParametrosAlternativa(questaoNumero, item, comandoInsercao);

                var id = comandoInsercao.ExecuteScalar();
            }

            conexaoComBanco.Close();

            return new ValidationResult();
        }

        private void ExcluirAlternativas(int numeroExclusao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(conexaoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlDeleteAlternativas, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("QUESTAO_NUMERO", numeroExclusao);

            conexaoComBanco.Open();

            comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        private void alterarAlternarivas(Questao registro)
        {
            ExcluirAlternativas(registro.Numero);
            InserirAlternativas(registro.Numero, registro.Alternativas);
        }

        private void ConfigurarParametrosAlternativa(int questaoNumero, Alternativa alternativa, SqlCommand comandoSql)
        {
            comandoSql.Parameters.AddWithValue("NUMERO", alternativa.Numero);
            comandoSql.Parameters.AddWithValue("DESCRICAO", alternativa.Descricao);
            comandoSql.Parameters.AddWithValue("CORRETA", alternativa.EstaCorreta);
            comandoSql.Parameters.AddWithValue("QUESTAO_NUMERO", questaoNumero);
        }
        #endregion

        #region Métodos próprios
        public List<Questao> ObterQuestoesRandomicas(List<Questao> questoesFiltradas, int quantidadeQuestoes)
        {
            if (quantidadeQuestoes > questoesFiltradas.Count)
                quantidadeQuestoes = questoesFiltradas.Count;

            List<Questao> questaoRandomicas = new List<Questao>();

            Random numero = new Random();


            while (questaoRandomicas.Count != quantidadeQuestoes)
            {
                int ranNum = numero.Next(0, quantidadeQuestoes);

                if (!questaoRandomicas.Exists(x => x.Numero == questoesFiltradas[ranNum].Numero))
                    questaoRandomicas.Add(questoesFiltradas[ranNum]);
            }


            return questaoRandomicas;
        }

        private Alternativa ConverterAlternativa(SqlDataReader leitoRegistro)
        {
            int numero = Convert.ToInt32(leitoRegistro["NUMERO"]);
            string descricao = Convert.ToString(leitoRegistro["DESCRICAO"]);
            bool coreta = Convert.ToBoolean(leitoRegistro["CORRETA"]);
            var Alternativa = new Alternativa
            {
                Numero = numero,
                Descricao = descricao,
                EstaCorreta = coreta
            };
            return Alternativa;
        }
        #endregion

        
    }
}
