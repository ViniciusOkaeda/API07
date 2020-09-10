using API07.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API07.Interfaces
{
    interface IPedidoItemRepository
    {
        List<PedidoItem> Listar();

        PedidoItem BuscarPorId(Guid id);

        void Adicionar(PedidoItem pedidoitem);

        void Editar(PedidoItem pedidoitem);

        void Remover(Guid id);
    }
}
