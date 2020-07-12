using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.ValueObjects
{
    public class CodigoDeBarras
    {
        public decimal TamanhoCodigo { get; private set; }
        public string TipoDeCodigo { get; private set; }
        public string Codigo { get; private set; }
    }
}
