using Dominio.GeradorProvas.Compartilhado;
using Dominio.GeradorProvas.ModuloQuestao;
using System;
using System.Collections.Generic;

namespace Dominio.GeradorProvas.ModuloTeste
{
    [Serializable]
    public class Teste : EntidadeBase<Teste>
    {
        public string Titulo { get; set; }
        public DisciplinaEnum Disciplina { get; set; }
        public SerieEnum Serie { get; set; }
        public int quantidadeQuestoes { get; set; }
        public List<ModuloQuestao.Questao> Questoes { get; set; }

        public Teste() { }

        public override void Atualizar(Teste registro)
        {
            this.Disciplina=registro.Disciplina;
            this.Serie=registro.Serie;
            this.quantidadeQuestoes=registro.quantidadeQuestoes;
            this.Questoes = registro.Questoes;
        }

        public override string ToString()
        {
            return $"Nº: {Numero} | Nome: {Titulo} | Diclipina {Disciplina} | Qtd. Questões: {quantidadeQuestoes}";
        }
    }
}
