using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Services;
using RookieEShop.Shared;
using System;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize("Bearer")]
	public class OrderController : Controller
	{
		private readonly IOrderService _IOrderService;

		public OrderController (IOrderService IOrderService)
		{
			_IOrderService = IOrderService;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<ActionResult> GetList(string id)
		{
			var listOrder = await _IOrderService.GetAddressShipping(id);

			return Ok(listOrder);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> AddOrder(OrderVm order)
		{
			var orders = new Ordering
			{
				Name = order.ClientName,
				Address = order.Address,
				CreatedAt = DateTime.Now,
				Phone = order.Phone,
				UserId = order.UserId
			};

			if (await _IOrderService.AddOrder(orders))
			{
				return StatusCode(201);
			}

			else
			{
				return StatusCode(400);
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> ChangeOrderStatus(int id, OrderEdit edit)
		{
			if (id <= 0) return StatusCode(400);
			
			if(await _IOrderService.ChangeStatus(id, edit))
			{
				return StatusCode(204);
			}

			else
			{
				return StatusCode(404);
			}
		}
	}
}
