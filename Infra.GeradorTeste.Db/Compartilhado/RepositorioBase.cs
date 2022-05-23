
using Dominio.GeradorProvas.Compartilhado;

namespace Infra.GeradorProvas.Db.Compartilhado
{
    public abstract class RepositorioBase<T> where T : EntidadeBase<T>
    {
        public abstract string EnderecoBanco { get; set; }
        public abstract string sqlInsert { get; set; }
        public abstract string sqlEdit { get; set; }
        public abstract string sqlDelete { get; set; }
        public abstract string sqlFindAll { get; set; }
        public abstract string sqlFindBy { get; set; }
    }
}
