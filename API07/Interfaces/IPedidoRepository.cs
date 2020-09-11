using API07.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API07.Interfaces
{
    interface IPedidoRepository
    {
        List<Pedido> Listar();

        Pedido BuscarPorId(Guid id);

        Pedido Adicionar(List<PedidoItem> pedidosItens);
    }
}
