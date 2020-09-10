using API07.Context;
using API07.Domains;
using API07.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API07.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }

        public void Adicionar(Pedido pedido)
        {
            try
            {
                //adiciona objeto do tipo produto ao dbset do contexto
                _ctx.Pedidos.Add(pedido);

                //salva as alterações no contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public List<Pedido> BuscarPorStatus(string status)
        {
            try
            {
                return _ctx.Pedidos.Where(c => c.Status.Contains(status)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Pedido pedido)
        {
            try
            {
                Pedido pedidoTemp = BuscarPorId(pedido.Id);
            if (pedidoTemp == null)
                throw new Exception("Produto não encontrado");

            pedidoTemp.Status = pedido.Status;
            pedidoTemp.OrderDate = pedido.OrderDate;

            _ctx.Pedidos.Update(pedidoTemp);
            _ctx.SaveChanges();
        }
            catch (Exception ex)
             {
                throw new Exception(ex.Message);
             }
}

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
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
                Pedido pedidoTemp = BuscarPorId(id);

                if (pedidoTemp == null)
                    throw new Exception("produto nao encontrado");

                _ctx.Pedidos.Remove(pedidoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
