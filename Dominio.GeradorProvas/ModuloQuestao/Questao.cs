using Dominio.GeradorProvas.Compartilhado;
using Dominio.GeradorProvas.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.GeradorProvas.ModuloQuestao
{
    [Serializable]
    public class Questao : EntidadeBase<Questao>
    {
        public Materia Materia { get; set; }
        public string Pergunta { get; set; }
        public List<Alternativa> Alternativas { get; set; }

        public Questao()
        {
            this.Alternativas = new List<Alternativa>();
        }
        public override void Atualizar(Questao registro)
        {
            this.Materia = registro.Materia;
            this.Pergunta = registro.Pergunta;
            this.Alternativas = registro.Alternativas;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

    }
}
