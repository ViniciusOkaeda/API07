using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API07.Domains;
using API07.Interfaces;
using API07.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API07.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PedidosController : ControllerBase
	{
		private readonly IPedidoRepository _pedidoRepository;

		public PedidosController()
		{
			_pedidoRepository = new PedidoRepository();
		}

		[HttpPost]

		public IActionResult Post(List<PedidoItem> pedidosItens)
		{
			try
			{
				//Adiciona um pedido
				Pedido pedido = _pedidoRepository.Adicionar(pedidosItens);
				return Ok(pedido);
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}



		[HttpGet("{Id}")]

		public IActionResult GetById(Guid id)
		{
			try
			{
				var pedido = _pedidoRepository.BuscarPorId(id);

				if (pedido == null)
					return NotFound();

				return Ok(pedido);
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message);

			}
		}
				[HttpGet]

		public IActionResult Get()
		{
			try
			{
				var pedidos = _pedidoRepository.Listar();

				if (pedidos.Count == 0)
					return NoContent();

				return Ok(pedidos);
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message);
			}


		}
	}
}
