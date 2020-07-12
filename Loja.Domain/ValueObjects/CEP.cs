using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.ValueObjects
{
    public class CEP
    {
        public string NumeroCep { get; private set; }
        public string Estado { get; set; }
    }
}
