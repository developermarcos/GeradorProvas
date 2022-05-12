using Dominio.GeradorProvas.Compartilhado;
using Dominio.GeradorProvas.ModuloQuestao;
using System;
using System.Collections.Generic;

namespace Dominio.GeradorProvas.ModuloTeste
{
    [Serializable]
    public class Teste : EntidadeBase<Teste>
    {
        public DiciplinaEnum Disciplina { get; set; }
        public SerieEnum Serie { get; set; }
        public int quantidadeQuestoes;
        List<Questao> questoes;

        public Teste() { }
        

        public override void Atualizar(Teste registro)
        {
            this.Disciplina=registro.Disciplina;
            this.Serie=registro.Serie;
            this.quantidadeQuestoes=registro.quantidadeQuestoes;
            this.questoes = registro.questoes;
        }

        public override string ToString()
        {
            return $"Nº: {Numero} | Diclipina {Disciplina} | Qtd. Questões: {quantidadeQuestoes}";
        }
    }
}
