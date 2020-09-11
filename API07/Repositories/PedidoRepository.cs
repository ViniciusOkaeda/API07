using API07.Context;
using API07.Domains;
using API07.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                // Criaçao do objeto do tipo pedido passando os valores
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado!",
                    OrderDate = DateTime.Now
            };
                //Percorre a lista de pedidos itens e adiciona a lista de pedidosItens
                foreach (var item in pedidosItens)
                {
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id,  //Id do objeto pedido criado acima
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    });
                }
                //Adiciono o meu pedido ao meu contexto
                _ctx.Pedidos.Add(pedido);
                //Salvo as alterações do contexto no banco
                _ctx.SaveChanges();

                return pedido;
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
                return _ctx.Pedidos.Include(c => c.PedidosItens).ThenInclude(c => c.Produto).FirstOrDefault( p => p.Id == id);
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
    }
}
