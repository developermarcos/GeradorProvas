using System;
using System.Collections.Generic;
using Dominio.GeradorProvas;
using Dominio.GeradorProvas.ModuloMateria;
using Dominio.GeradorProvas.Compartilhado;
using System.Data.SqlClient;
using Infra.GeradorProvas.Db.ModuloMateira;

namespace Apresentacao.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Materia novaMateria = new Materia(DiciplinaEnum.Matemática, SerieEnum.Primeira, "Subtração");
            IRepositorioMateria repositorioMateria = new RepositorioMateria();
            var teste = repositorioMateria.SelecionarTodos();
            var registroPorId = repositorioMateria.SelecionarPorNumero(2);
            //repositorioMateria.Inserir(novaMateria);

            //novaMateria.Descricao = "Subtração alterada";
            //repositorioMateria.Editar(novaMateria);

            //novaMateria.Numero = 3;

            //repositorioMateria.Excluir(novaMateria);
            System.Console.ReadKey();

        }

        private static Materia SelecionarMateriaPorNumero(int numeroPesquisado)
        {
            #region abrir a conexão com o banco de dados
            string enderecoBanco =
                "Data Source=(LocalDB)\\MSSqlLocalDB;" +
                "Initial Catalog=GeradorProvasDb;" +
                "Integrated Security=True;" +
                "Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoBanco;
            conexaoComBanco.Open();
            #endregion

            #region  criar um comando 
            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;
            string sql = @"SELECT 
		                        [NUMERO], 
		                        [DESCRICAO], 
		                        [DISCIPLINA],
		                        [SERIE]
	                        FROM 
		                        [TBMateria]
		                    WHERE
                                [NUMERO] = @NUMERO";

            comandoSelecao.CommandText = sql;

            #endregion

            comandoSelecao.Parameters.AddWithValue("NUMERO", numeroPesquisado);

            //executar o comando
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            Materia Materia = null;
            if (leitorMateria.Read())
            {
                int numero = Convert.ToInt32(leitorMateria["NUMERO"]);
                string descricao = Convert.ToString(leitorMateria["DESCRICAO"]);
                DiciplinaEnum disciplina = (DiciplinaEnum)Convert.ToInt32(leitorMateria["DISCIPLINA"]);
                SerieEnum serie = (SerieEnum)Convert.ToInt32(leitorMateria["SERIE"]);
                
                Materia = new Materia
                {
                    Numero = numero,
                    Descricao = descricao,
                    Disciplina = disciplina,
                    Serie = serie
                };
            }

            //fechar a conexão
            conexaoComBanco.Close();

            return Materia;
        }

        private static List<Materia> SelecionarTodosMaterias()
        {
            #region abrir a conexão com o banco de dados
            string enderecoBanco =
                "Data Source=(LocalDB)\\MSSqlLocalDB;" +
                "Initial Catalog=GeradorProvasDb;" +
                "Integrated Security=True;" +
                "Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoBanco;
            conexaoComBanco.Open();
            #endregion

            #region  criar um comando 
            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;
            string sql = @"SELECT 
		                        [NUMERO], 
		                        [DESCRICAO], 
		                        [DISCIPLINA],
		                        [SERIE]
	                        FROM 
		                        [TBMateria]";

            comandoSelecao.CommandText = sql;

            #endregion

            //executar o comando
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            List<Materia> Materias = new List<Materia>();

            while (leitorMateria.Read())
            {
                int numero = Convert.ToInt32(leitorMateria["NUMERO"]);
                string descricao = Convert.ToString(leitorMateria["DESCRICAO"]);
                DiciplinaEnum disciplina = (DiciplinaEnum)Convert.ToInt32(leitorMateria["DISCIPLINA"]);
                SerieEnum serie = (SerieEnum)Convert.ToInt32(leitorMateria["SERIE"]);

                Materia Materia = new Materia
                {
                    Numero = numero,
                    Descricao = descricao,
                    Disciplina = disciplina,
                    Serie = serie
                };

                Materias.Add(Materia);
            }

            //fechar a conexão
            conexaoComBanco.Close();

            return Materias;
        }

        private static void ExcluirMateria(int numero)
        {
            #region abrir a conexão com o banco de dados
            string enderecoBanco =
                "Data Source=(LocalDB)\\MSSqlLocalDB;" +
                "Initial Catalog=GeradorProvasDb;" +
                "Integrated Security=True;" +
                "Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoBanco;
            conexaoComBanco.Open();
            #endregion

            #region  criar um comando de edição
            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = conexaoComBanco;
            string sql = @"	DELETE FROM [TBMateria]
		                        WHERE
			                        [NUMERO] = @NUMERO";

            comandoExclusao.CommandText = sql;

            #endregion

            #region passar os parâmetros para o comando de inserção
            comandoExclusao.Parameters.AddWithValue("NUMERO", numero);
            #endregion

            //executar o comando
            comandoExclusao.ExecuteNonQuery();

            //fechar a conexão
            conexaoComBanco.Close();
        }

        private static void EditarMateria(Materia Materia)
        {
            #region abrir a conexão com o banco de dados
            string enderecoBanco =
                "Data Source=(LocalDB)\\MSSqlLocalDB;" +
                "Initial Catalog=GeradorProvasDb;" +
                "Integrated Security=True;" +
                "Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoBanco;
            conexaoComBanco.Open();
            #endregion

            #region  criar um comando de edição
            SqlCommand comandoEdicao = new SqlCommand();
            comandoEdicao.Connection = conexaoComBanco;
            string sql = @"	UPDATE [TBMateria]	
		                        SET
			                        [DESCRICAO] = @DESCRICAO,
			                        [DISCIPLINA] = @DISCIPLINA,
			                        [SERIE] = @SERIE
		                        WHERE
			                        [NUMERO] = @NUMERO";

            comandoEdicao.CommandText = sql;

            #endregion

            #region passar os parâmetros para o comando de inserção
            comandoEdicao.Parameters.AddWithValue("NUMERO", Materia.Numero);
            comandoEdicao.Parameters.AddWithValue("DESCRICAO", Materia.Descricao);
            comandoEdicao.Parameters.AddWithValue("DISCIPLINA", Materia.Disciplina);
            comandoEdicao.Parameters.AddWithValue("SERIE", Materia.Serie);
            #endregion

            //executar o comando
            comandoEdicao.ExecuteNonQuery();

            //fechar a conexão
            conexaoComBanco.Close();
        }

        private static void InserirMateria(Materia novoMateria)
        {
            #region abrir a conexão com o banco de dados
            string enderecoBanco =
                "Data Source=(LocalDB)\\MSSqlLocalDB;" +
                "Initial Catalog=GeradorProvasDb;" +
                "Integrated Security=True;" +
                "Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoBanco;
            conexaoComBanco.Open();
            #endregion

            #region  criar um comando de inserção
            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = conexaoComBanco;
            string sql = @"INSERT INTO [TbMateria] 
                            (
                                [DESCRICAO],
                                [DISCIPLINA],
                                [SERIE]
	                        )
	                        VALUES
                            (
                                @DESCRICAO,
                                @DISCIPLINA,
                                @SERIE
                            );";

            sql += "SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sql;

            #endregion

            #region passar os parâmetros para o comando de inserção
            comandoInsercao.Parameters.AddWithValue("DESCRICAO", novoMateria.Descricao);
            comandoInsercao.Parameters.AddWithValue("DISCIPLINA", (int)novoMateria.Disciplina);
            comandoInsercao.Parameters.AddWithValue("SERIE", (int)novoMateria.Serie);
            #endregion

            //executar o comando
            try
            {
                var id = comandoInsercao.ExecuteScalar();
                novoMateria.Numero = Convert.ToInt32(id);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            

            

            //fechar a conexão
            conexaoComBanco.Close();
        }

    }
}
