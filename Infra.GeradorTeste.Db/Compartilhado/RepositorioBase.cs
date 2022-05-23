
using Dominio.GeradorProvas.Compartilhado;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infra.GeradorProvas.Db.Compartilhado
{
    public abstract class RepositorioBase<T> where T : EntidadeBase<T>
    {
        private readonly string conexaoBanco =
            "Data Source=(LocalDB)\\MSSqlLocalDB;" +
              "Initial Catalog=GeradorProvasDb;" +
              "Integrated Security=True;" +
              "Pooling=False";
        protected abstract string SqlFindAll { get; }
               

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

            comandoSelecao.CommandText = SqlFindAll;

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

        public abstract T ConverterRegistro(SqlDataReader leitorContato);
    }
}
