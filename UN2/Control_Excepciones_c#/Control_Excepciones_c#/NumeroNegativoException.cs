using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Excepciones_c_
{
    internal class NumeroNegativoException:Exception
    {
        public NumeroNegativoException() : base() { }
        public NumeroNegativoException(string msg) : base(msg) { }
    }
}
