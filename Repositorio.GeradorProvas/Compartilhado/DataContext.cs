
using Dominio.GeradorProvas.ModuloMateria;
using Dominio.GeradorProvas.ModuloQuestao;
using Infra.GeradorProvas.Compartilhado.Serializador;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.GeradorProvas.Compartilhado
{
    
    [Serializable]
    public class DataContext //Container
    {
        private readonly ISerializador serializador;

        public DataContext()
        {
            Materias = new List<Materia>();
            Questoes = new List<Questao>();
        }

        public DataContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public List<Materia> Materias { get; set; }
        public List<Questao> Questoes { get; set; }


        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();
            
            if(ctx != null)
            {
                if (ctx.Materias.Any())
                    this.Materias.AddRange(ctx.Materias);

                if (ctx.Questoes.Any())
                    this.Questoes.AddRange(ctx.Questoes);
            }

        }
    }
}
