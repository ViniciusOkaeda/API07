using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API07.Domains;
using API07.Interfaces;
using API07.Repositories;
using API07.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly IProdutoRepository _produtorepository;

        public ProdutosController()
        {
            _produtorepository = new ProdutoRepository();
        }
        // GET: api/<ProdutoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //lista os produtos no repositorio
                var produtos = _produtorepository.Listar();

                //verifica se existe produtos, caso não exista ele retorna NoContent() - sem conteúdo
                //caso exista retorna ok e os produtos
                if (produtos.Count == 0)
                    return NoContent();

                return Ok(new { 
                totalCount = produtos.Count,
                data = produtos
                });
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna badrequest e a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //Busca o produto no repositorio
                Produto produto = _produtorepository.BuscarPorId(id);

                //Verifica se o produto existe 
                //caso nao exista, retorna NotFound
                if (produto == null)
                    return NotFound();

                //Caso o produto exista
                //Retorna ok e os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public IActionResult Post(Produto produto)
        {

            try
            {
                if (produto.Imagem != null)
                {
                    var urlImagem = Upload.Local(produto.Imagem);

                    produto.UrlImagem = urlImagem;
                }

                    // Adiciona um produto 
                    _produtorepository.Adicionar(produto);

                //Retorna ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                _produtorepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            try
            {
                _produtorepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }
    }
}
