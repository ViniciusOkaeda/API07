using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API07.Domains
{
    public class Pedido : BaseDomain
    {
        public string Status { get; set; }

        public DateTime OrderDate { get; set; }

        // Relacionamento com a tabela PedidoItem 1,n
        public List<PedidoItem> PedidosItens;

        public Pedido()
        {
            PedidosItens = new List<PedidoItem>();
        }
    }
}
