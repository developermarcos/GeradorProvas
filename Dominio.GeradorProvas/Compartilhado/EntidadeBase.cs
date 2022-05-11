namespace Dominio.GeradorProvas.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public int Numero { get; set; }

        public abstract void Atualizar(T registro);

        public abstract override string ToString();
    }
}
