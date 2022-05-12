
using Dominio.GeradorProvas.ModuloMateria;
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
        private SerializadorDadosEmJsonDotnet serializador1;

        public DataContext()
        {
        }

        public DataContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            Materias = new List<Materia>();

            CarregarDados();
        }

        public List<Materia> Materias { get; set; }


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
            }

        }
    }
}
