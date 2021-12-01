using Microsoft.AspNetCore.Mvc;
using RookieEShop.FrontEnd.Services;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderApiClient _orderApiClient;

		public OrderController(IOrderApiClient orderApiClient)
		{
			_orderApiClient = orderApiClient;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> History()
		{
			var history = await _orderApiClient.GetHistory();
			return View(history);
		}

		[Route("history/{id:int}", Name ="history")]
		public async Task<IActionResult> Detail(int id)
		{
			var history = await _orderApiClient.GetHistory();
			var detail = history.Where(x => x.OrderId.Equals(id)).First();
			return View(detail);
		}

		[Route("cancelorder/{id:int}", Name ="cancelorder")]
		public async Task<IActionResult> CancelOrder(int id)
		{
			var order = new OrderEdit
			{
				Status = "Cancel"
			};

			var isSuccess = await _orderApiClient.UpdateOrderStatus(id, order);

			if (isSuccess)
			{
				return RedirectToAction("Detail", "Order", new { id = id });
			}

			return RedirectToAction("Error", "Cart");
		}
	}
}
