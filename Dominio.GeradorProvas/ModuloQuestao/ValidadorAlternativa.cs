﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.GeradorProvas.ModuloQuestao
{
    public class ValidadorAlternativa : AbstractValidator<Alternativa>
    {
        public ValidadorAlternativa()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .NotNull();
        }
    }
}
