
using Dominio.GeradorProvas.Compartilhado;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infra.GeradorProvas.Db.Compartilhado
{
    public abstract class RepositorioBase<T> where T : EntidadeBase<T>
    {
        protected readonly string conexaoBanco =
            "Data Source=(LocalDB)\\MSSqlLocalDB;" +
              "Initial Catalog=GeradorProvasDb;" +
              "Integrated Security=True;" +
              "Pooling=False";
        protected abstract string SqlSelectAll { get; }
        protected abstract string SqlInsert { get; }       
        protected abstract string SqlDelete { get; }       
        protected abstract string SqlEdit { get; }       
        protected abstract string SqlSelectBy { get; }       

        public virtual List<T> SelecionarTodos()
        {
            #region abrir a conexão com o banco de dados

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = conexaoBanco;
            conexaoComBanco.Open();

            #endregion

            #region  criar um comando 
            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            comandoSelecao.CommandText = SqlSelectAll;

            #endregion

            //executar o comando
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            var registros = new List<T>();

            while (leitorMateria.Read())
            {
                registros.Add(ConverterRegistro(leitorMateria));
            }

            //fechar a conexão
            conexaoComBanco.Close();

            return registros;
        }

        public virtual ValidationResult Inserir(T novoRegistro)
        {

            var validador = ObterValidador();

            var resultadoValidacao = validador.Validate(novoRegistro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(conexaoBanco);

            SqlCommand comandoInsercao = new SqlCommand(SqlInsert, conexaoComBanco);

            ConfigurarParametrosRegistro(novoRegistro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novoRegistro.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public virtual ValidationResult Excluir(T registro)
        {
            ValidationResult resultadoValidacao = new ValidationResult();

            SqlConnection conexaoComBanco = new SqlConnection(conexaoBanco);

            SqlCommand comandoInsercao = new SqlCommand(SqlDelete, conexaoComBanco);

            ConfigurarParametrosRegistro(registro, comandoInsercao);

            conexaoComBanco.Open();

            var id = comandoInsercao.ExecuteNonQuery();

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public virtual ValidationResult Editar(T registro)
        {
            var validador = ObterValidador();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(conexaoBanco);

            SqlCommand comandoInsercao = new SqlCommand(SqlEdit, conexaoComBanco);

            ConfigurarParametrosRegistro(registro, comandoInsercao);

            conexaoComBanco.Open();
            
            comandoInsercao.ExecuteNonQuery();
            
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public virtual T SelecionarPorNumero(int numero)
        {
            #region abrir a conexão com o banco de dados

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = conexaoBanco;
            conexaoComBanco.Open();

            #endregion

            #region  criar um comando 
            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            comandoSelecao.CommandText = SqlSelectBy;

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            #endregion

            //executar o comando
            SqlDataReader leitoRegistro = comandoSelecao.ExecuteReader();

            T registroSelecionado = null;

            if (leitoRegistro.Read())
            {
                registroSelecionado = ConverterRegistro(leitoRegistro);
            }

            //fechar a conexão
            conexaoComBanco.Close();

            return registroSelecionado;
        }

        public abstract T ConverterRegistro(SqlDataReader leitorContato);

        public abstract AbstractValidator<T> ObterValidador();

        public abstract void ConfigurarParametrosRegistro(T registro, SqlCommand comandoSql);
    }
}
