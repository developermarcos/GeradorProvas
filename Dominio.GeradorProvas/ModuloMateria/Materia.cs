using Dominio.GeradorProvas.Compartilhado;
using System;

namespace Dominio.GeradorProvas.ModuloMateria
{
    [Serializable]
    public class Materia : EntidadeBase<Materia>
    {
        public DiciplinaEnum Disciplina { get; set; }
        public SerieEnum Serie { get; set; }
        public string Descricao { get; set; }

        public Materia() { }
        public Materia(DiciplinaEnum Disciplina, SerieEnum serie, string nome)
        {
            this.Disciplina=Disciplina;
            this.Serie=serie;
            this.Descricao=nome;
        }

        public override void Atualizar(Materia registro)
        {
            this.Disciplina=registro.Disciplina;
            this.Serie=registro.Serie;
            this.Descricao=registro.Descricao;
        }

        public override string ToString()
        {
            return $"Nº: {Numero} | Diclipina {Disciplina} | Matéria: {Descricao}";
        }
    }
}
