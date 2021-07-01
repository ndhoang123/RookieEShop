using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RookieEShop.BackEnd.Services;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize("Bearer")]
	public class CartController : ControllerBase
	{
		private readonly ICartService _cartService;
		
		public CartController(ICartService cartService)
		{
			_cartService = cartService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<IEnumerable<CartVm>>> GetAllCart()
		{
			var listCart = await _cartService.GetAllList();

			return Ok(listCart);
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<ActionResult<CartVm>> GetDetailCart(int id)
		{
			if (id < 1) return BadRequest();

			var detailCart = await _cartService.GetDetailList(id);

			if (detailCart == null) return NotFound();

			return Ok(detailCart);
		}
	}
}
