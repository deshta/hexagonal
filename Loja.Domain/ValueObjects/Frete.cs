using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.ValueObjects
{
    public class Frete
    {
        public CEP Cep { get; private set; }
        public float Valor { get; private set; }
    }
}
