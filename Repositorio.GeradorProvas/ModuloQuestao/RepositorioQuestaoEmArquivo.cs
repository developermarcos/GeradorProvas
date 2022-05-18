using Dominio.GeradorProvas.ModuloQuestao;
using FluentValidation;
using FluentValidation.Results;
using Infra.GeradorProvas.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.GeradorProvas.ModuloQuestao
{
    public class RepositorioQuestaoEmArquivo : RepositorioEmArquivoBase<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestaoEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Questoes.Count > 0)
                contador = dataContext.Questoes.Max(x => x.Numero);
        }

        public override List<Questao> ObterRegistros()
        {
            return dataContext.Questoes;
        }

        public override AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();
        }

        public override ValidationResult Inserir(Questao novoRegistro)
        {
            bool perguntaJaCadastrada = dataContext.Questoes.Exists(x => x.Pergunta.ToUpper() == novoRegistro.Pergunta.ToUpper());

            if (perguntaJaCadastrada)
                return ValidaPerguntaCadastrada("Questão não cadastrada, pergunta ja foi utilizada em outra questão");
            

            ValidationResult validaAlternativas = ValidarAlternativas(novoRegistro);

            if (!validaAlternativas.IsValid)
                return validaAlternativas;
            
            
            return base.Inserir(novoRegistro);
        }

        public override ValidationResult Editar(Questao registro)
        {
            bool perguntaJaCadastrada = dataContext.Questoes
                .Exists(x => x.Pergunta.ToUpper() == registro.Pergunta.ToUpper()
                        && x.Numero != registro.Numero);

            if (perguntaJaCadastrada)
                return ValidaPerguntaCadastrada("Questão não editada, pergunta ja foi utilizada em outra questão");
            

            ValidationResult validaAlternativas = ValidarAlternativas(registro);

            if (!validaAlternativas.IsValid)
            {
                return validaAlternativas;
            }

            return base.Editar(registro);
        }

        private ValidationResult ValidarAlternativas(Questao questao)
        {
            ValidationResult validador = new ValidationResult();

            if (questao.Alternativas.Count(x => x.EstaCorreta == true) != 1)
            {
                ValidationFailure perguntaRepetida = new ValidationFailure("", "A questão deve conter apenas uma alternativa verdadeira.");

                validador.Errors.Add(perguntaRepetida);
            }

            if(questao.Alternativas.Count < 2)
            {
                ValidationFailure perguntaRepetida = new ValidationFailure("", "A questão deve conter no mínimo duas alternativas.");

                validador.Errors.Add(perguntaRepetida);
            }

            List<string> listaTitulo = new List<string>();
            foreach (var item in questao.Alternativas)
                listaTitulo.Add(item.Descricao.ToUpper());
            
            if(listaTitulo.Count != listaTitulo.Distinct().ToList().Count)
            {
                ValidationFailure perguntaRepetida = new ValidationFailure("", "Alternativas duplicadas.");

                validador.Errors.Add(perguntaRepetida);
            }
                
            return validador;
        }

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

        private ValidationResult ValidaPerguntaCadastrada(string menssage)
        {
            ValidationFailure perguntaRepetida = new ValidationFailure("", menssage);

            ValidationResult validador = new ValidationResult();

            validador.Errors.Add(perguntaRepetida);

            return validador;
        }
    }
}
