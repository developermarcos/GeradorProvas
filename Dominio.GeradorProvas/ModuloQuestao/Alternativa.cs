using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.GeradorProvas.ModuloQuestao
{
    [Serializable]
    public class Alternativa
    {
        public string Descricao { get; set; }
        public bool EstaCorreta { get; set; }

        public override string ToString()
        {
            string status = EstaCorreta == true ? "Correta" : "Falsa";
            return $"Alternariva: {Descricao} | {status}";
        }
        public void AtualizarRegistro(Alternativa alternativa)
        {
            this.Descricao = alternativa.Descricao;
            this.EstaCorreta = alternativa.EstaCorreta;
        }
    }
}
