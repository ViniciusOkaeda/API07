using API07.Context;
using API07.Domains;
using API07.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API07.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }
        public void Adicionar(Produto produto)
        {
            try
            {
                //adiciona objeto do tipo produto ao dbset do contexto
                _ctx.Produtos.Add(produto);

                //salva as alterações no contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produto BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Produtos.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Produto produto)
        {
            try
            {
                Produto produtoTemp = BuscarPorId(produto.Id);

                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                _ctx.Produtos.Update(produtoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
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
                Produto produtoTemp = BuscarPorId(id);

                if (produtoTemp == null)
                    throw new Exception("produto nao encontrado");

                _ctx.Produtos.Remove(produtoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
