using Dominio.GeradorProvas;
using Dominio.GeradorProvas.ModuloMateria;
using FluentValidation;
using FluentValidation.Results;
using Infra.GeradorProvas.Db.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Infra.GeradorProvas.Db.ModuloMateira
{
    public class RepositorioMateria : RepositorioBase<Materia>, IRepositorioMateria
    {
        #region Scripts SQL
        private readonly string sqlSelectAll =
            @"SELECT 
		                        [NUMERO], 
		                        [DESCRICAO], 
		                        [DISCIPLINA],
		                        [SERIE]
	                        FROM 
		                        [TBMateria]";
        
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
        
        private readonly string sqlDelete =
            @"	DELETE FROM [TBMateria]
		                        WHERE
			                        [NUMERO] = @NUMERO";

        private readonly string sqlEdit =
            @"	UPDATE [TBMateria]	
		                        SET
			                        [DESCRICAO] = @DESCRICAO,
			                        [DISCIPLINA] = @DISCIPLINA,
			                        [SERIE] = @SERIE
		                        WHERE
			                        [NUMERO] = @NUMERO";

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

        protected override string SqlSelectAll => sqlSelectAll;

        protected override string SqlInsert => sqlInsert;

        protected override string SqlDelete => sqlDelete;

        protected override string SqlEdit => sqlEdit;

        protected override string SqlSelectBy => sqlSelectBy;
        #endregion

        #region Métodos Obrigatórios
        public override void ConfigurarParametrosRegistro(Materia registro, SqlCommand comandoSql)
        {
            comandoSql.Parameters.AddWithValue("NUMERO", registro.Numero);
            comandoSql.Parameters.AddWithValue("DESCRICAO", registro.Descricao);
            comandoSql.Parameters.AddWithValue("DISCIPLINA", (int)registro.Disciplina);
            comandoSql.Parameters.AddWithValue("SERIE", (int)registro.Serie);
        }

        public override Materia ConverterRegistro(SqlDataReader leitorContato)
        {
            int numero = Convert.ToInt32(leitorContato["NUMERO"]);
            string descricao = Convert.ToString(leitorContato["DESCRICAO"]);
            DisciplinaEnum disciplina = (DisciplinaEnum)Convert.ToInt32(leitorContato["DISCIPLINA"]);
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

        public override AbstractValidator<Materia> ObterValidador()
        {
            return new ValidadorMateria();
        }
        #endregion
    }
}
