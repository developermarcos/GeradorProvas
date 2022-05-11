using Infra.GeradorProvas.Compartilhado;
namespace Infra.GeradorProvas.Compartilhado.Serializador
{
    public interface ISerializador
    {
        DataContext CarregarDadosDoArquivo();

        void GravarDadosEmArquivo(DataContext dados);
    }
}
