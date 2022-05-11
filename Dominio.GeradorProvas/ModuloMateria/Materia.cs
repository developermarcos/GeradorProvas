using Dominio.GeradorProvas.Compartilhado;
using System;

namespace Dominio.GeradorProvas.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public DiciplinaEnum diciplina;
        public SerieEnum serie;
        public string nome;

        public Materia(DiciplinaEnum diciplina, SerieEnum serie, string nome)
        {
            this.diciplina=diciplina;
            this.serie=serie;
            this.nome=nome;
        }

        public override void Atualizar(Materia registro)
        {
            this.diciplina=registro.diciplina;
            this.serie=registro.serie;
            this.nome=registro.nome;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
