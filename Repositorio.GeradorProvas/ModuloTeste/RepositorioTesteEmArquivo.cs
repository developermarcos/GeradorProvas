using Dominio.GeradorProvas.ModuloQuestao;
using Dominio.GeradorProvas.ModuloTeste;
using FluentValidation;
using FluentValidation.Results;
using Infra.GeradorProvas.Compartilhado;
using System;
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
        public override ValidationResult Inserir(Teste novoRegistro)
        {

            bool perguntaJaCadastrada = dataContext.Testes.Exists(x => x.Titulo.ToUpper() == novoRegistro.Titulo.ToUpper());

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

            return base.Inserir(novoRegistro);
        }

        public override ValidationResult Editar(Teste registro)
        {
            bool perguntaJaCadastrada = dataContext.Testes
                .Exists(x => x.Titulo.ToUpper() == registro.Titulo.ToUpper()
                        && x.Numero != registro.Numero);

            if (perguntaJaCadastrada)
            {
                ValidationFailure perguntaRepetida = new ValidationFailure("", "Questão não cadastrada, pergunta ja foi utilizada em outra questão");

                ValidationResult validador = new ValidationResult();

                validador.Errors.Add(perguntaRepetida);

                return validador;
            }

            return base.Editar(registro);
        }

    }
}
