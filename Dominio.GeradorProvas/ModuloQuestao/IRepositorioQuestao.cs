using Dominio.GeradorProvas.Compartilhado;
using System.Collections.Generic;

namespace Dominio.GeradorProvas.ModuloQuestao
{
    public interface IRepositorioQuestao : IRepositorio<Questao>
    {
        public List<Questao> ObterQuestoesRandomicas(List<Questao> questoesFiltradas, int quantidadeQuestoes);
    }
}
