using Dominio.GeradorProvas.Compartilhado;
using System;

namespace Dominio.GeradorProvas.ModuloMateria
{
    [Serializable]
    public class Materia : EntidadeBase<Materia>
    {
        public DisciplinaEnum Disciplina { get; set; }
        public SerieEnum Serie { get; set; }
        public string Descricao { get; set; }

        public Materia() { }
        public Materia(DisciplinaEnum Disciplina, SerieEnum serie, string descricao)
        {
            this.Disciplina=Disciplina;
            this.Serie=serie;
            this.Descricao=descricao;
        }

        public override void Atualizar(Materia registro)
        {
            this.Disciplina=registro.Disciplina;
            this.Serie=registro.Serie;
            this.Descricao=registro.Descricao;
        }

        public override string ToString()
        {
            return $"{Numero}- {Descricao}";
        }
    }
}
