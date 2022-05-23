using Dominio.GeradorProvas;
using Dominio.GeradorProvas.ModuloMateria;
using FluentValidation.Results;
using Infra.GeradorProvas.Db.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.GeradorProvas.Db.ModuloMateira
{
    public class RepositorioMateria : IRepositorioMateria
    {
        private readonly string enderecoBanco =
            "Data Source=(LocalDB)\\MSSqlLocalDB;" +
              "Initial Catalog=GeradorProvasDb;" +
              "Integrated Security=True;" +
              "Pooling=False";


        private readonly string sqlInsert =
            @"INSERT INTO [TbMateria] 
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
                        );
                SELECT SCOPE_IDENTITY();";

        private readonly string sqlEdit=
            @"	UPDATE [TBMateria]	
		                        SET
			                        [DESCRICAO] = @DESCRICAO,
			                        [DISCIPLINA] = @DISCIPLINA,
			                        [SERIE] = @SERIE
		                        WHERE
			                        [NUMERO] = @NUMERO";

        private readonly string sqlDelete =
            @"	DELETE FROM [TBMateria]
		                        WHERE
			                        [NUMERO] = @NUMERO";

        private readonly string sqlSelectAll =
            @"SELECT 
		                        [NUMERO], 
		                        [DESCRICAO], 
		                        [DISCIPLINA],
		                        [SERIE]
	                        FROM 
		                        [TBMateria]";

        private readonly string sqlSelectBy =
            @"SELECT 
		                        [NUMERO], 
		                        [DESCRICAO], 
		                        [DISCIPLINA],
		                        [SERIE]
	                        FROM 
		                        [TBMateria]

                            WHERE
                                [NUMERO] = @NUMERO";

        public ValidationResult Editar(Materia registro)
        {
            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlEdit, conexaoComBanco);

            ConfigurarParametrosContato(registro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            registro.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Materia registro)
        {
            ValidationResult resultadoValidacao = new ValidationResult();

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlDelete, conexaoComBanco);

            ConfigurarParametrosContato(registro, comandoInsercao);

            conexaoComBanco.Open();

            var id = comandoInsercao.ExecuteScalar();

            registro.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Inserir(Materia novoRegistro)
        {

            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(novoRegistro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInsert, conexaoComBanco);

            ConfigurarParametrosContato(novoRegistro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novoRegistro.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public Materia SelecionarPorNumero(int numero)
        {
            #region abrir a conexão com o banco de dados

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoBanco;
            conexaoComBanco.Open();

            #endregion

            #region  criar um comando 
            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            comandoSelecao.CommandText = sqlSelectBy;

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            #endregion

            //executar o comando
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            Materia materiaSelecionada = new Materia();
            
            if (leitorMateria.Read())
            {
                materiaSelecionada = ConverterParaMateria(leitorMateria);
            }
            
            //fechar a conexão
            conexaoComBanco.Close();

            return materiaSelecionada;
        }

        public List<Materia> SelecionarTodos()
        {
            #region abrir a conexão com o banco de dados
            
            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoBanco;
            conexaoComBanco.Open();

            #endregion

            #region  criar um comando 
            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;
            
            comandoSelecao.CommandText = sqlSelectAll;

            #endregion

            //executar o comando
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            List<Materia> Materias = new List<Materia>();

            while (leitorMateria.Read())
            {
                Materias.Add(ConverterParaMateria(leitorMateria));
            }

            //fechar a conexão
            conexaoComBanco.Close();

            return Materias;
        }

        private static void ConfigurarParametrosContato(Materia novaMateria, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", novaMateria.Numero);
            comando.Parameters.AddWithValue("DESCRICAO", novaMateria.Descricao);
            comando.Parameters.AddWithValue("DISCIPLINA", (int)novaMateria.Disciplina);
            comando.Parameters.AddWithValue("SERIE", (int)novaMateria.Serie);
        }

        private static Materia ConverterParaMateria(SqlDataReader leitorContato)
        {
            int numero = Convert.ToInt32(leitorContato["NUMERO"]);
            string descricao = Convert.ToString(leitorContato["DESCRICAO"]);
            DiciplinaEnum disciplina = (DiciplinaEnum)Convert.ToInt32(leitorContato["DISCIPLINA"]);
            SerieEnum serie = (SerieEnum)Convert.ToInt32(leitorContato["SERIE"]);

            var Materia = new Materia
            {
                Numero = numero,
                Descricao = descricao,
                Disciplina = disciplina,
                Serie = serie
            };

            return Materia;
        }
    }
}
