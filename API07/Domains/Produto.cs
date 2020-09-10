using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API07.Domains
{
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }

        public float Preco { get; set; }
    }
}
