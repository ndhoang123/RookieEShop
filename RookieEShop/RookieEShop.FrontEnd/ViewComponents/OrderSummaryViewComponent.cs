using Microsoft.AspNetCore.Mvc;
using RookieEShop.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.ViewComponents
{
	public class OrderSummaryViewComponent : ViewComponent
	{
		private readonly ICartApiClient _cartApiClient;

		public OrderSummaryViewComponent(ICartApiClient cartApiClient)
		{
			_cartApiClient = cartApiClient;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var cart = await _cartApiClient.GetAllCart();
			return View(cart);
		}
	}
}
