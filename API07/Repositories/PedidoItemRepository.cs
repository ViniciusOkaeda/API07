using API07.Context;
using API07.Domains;
using API07.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API07.Repositories
{
    public class PedidoItemRepository : IPedidoItemRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoItemRepository()
        {
            _ctx = new PedidoContext();
        }

        public void Adicionar(PedidoItem pedidoitem)
        {
            try
            {
                //adiciona objeto do tipo produto ao dbset do contexto
                _ctx.PedidosItens.Add(pedidoitem);

                //salva as alterações no contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PedidoItem BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.PedidosItens.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Editar(PedidoItem pedidoitem)
        {
            try
            {
                PedidoItem pedidoitemTemp = BuscarPorId(pedidoitem.Id);
                if (pedidoitemTemp == null)
                    throw new Exception("Produto não encontrado");

                pedidoitemTemp. IdProduto = pedidoitem.IdProduto;
                pedidoitemTemp.Produto = pedidoitem.Produto;
                pedidoitemTemp.IdPedido = pedidoitem.IdPedido;
                pedidoitemTemp.Pedido = pedidoitem.Pedido;
                pedidoitemTemp.Quantidade = pedidoitem.Quantidade;

                _ctx.PedidosItens.Update(pedidoitemTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PedidoItem> Listar()
        {
            try
            {
                return _ctx.PedidosItens.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                PedidoItem pedidoitemTemp = BuscarPorId(id);

                if (pedidoitemTemp == null)
                    throw new Exception("produto nao encontrado");

                _ctx.PedidosItens.Remove(pedidoitemTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
