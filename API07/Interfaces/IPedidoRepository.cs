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

        List<Pedido> BuscarPorStatus(string status);

        Pedido BuscarPorId(Guid id);

        void Adicionar(Pedido pedido);

        void Editar(Pedido pedido);

        void Remover(Guid id);
    }
}
