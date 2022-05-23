using Dominio.GeradorProvas;
using Dominio.GeradorProvas.ModuloMateria;
using FluentValidation.Results;
using Infra.GeradorProvas.Db.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Infra.GeradorProvas.Db.ModuloMateira
{
    public class RepositorioMateria : RepositorioBase<Materia>, IRepositorioMateria
    {
        private readonly string sqlSelectAll =
            @"SELECT 
		                        [NUMERO], 
		                        [DESCRICAO], 
		                        [DISCIPLINA],
		                        [SERIE]
	                        FROM 
		                        [TBMateria]";
        protected override string SqlFindAll { get => sqlSelectAll; }

        public override Materia ConverterRegistro(SqlDataReader leitorContato)
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

        public ValidationResult Editar(Materia registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Materia registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Inserir(Materia novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Materia SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }
    }
}
