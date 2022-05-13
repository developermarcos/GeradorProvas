using Dominio.GeradorProvas;
using Dominio.GeradorProvas.ModuloQuestao;
using Dominio.GeradorProvas.ModuloTeste;
using FluentValidation;
using Infra.GeradorProvas.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace Infra.GeradorProvas.ModuloTeste
{
    public class RepositorioTesteEmArquivo : RepositorioEmArquivoBase<Teste>, IRepositorioTeste
    {
        public RepositorioTesteEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Testes.Count > 0)
                contador = dataContext.Testes.Max(x => x.Numero);
        }

        public override List<Teste> ObterRegistros()
        {
            return dataContext.Testes;
        }

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidadorTeste();
        }

    }
}
