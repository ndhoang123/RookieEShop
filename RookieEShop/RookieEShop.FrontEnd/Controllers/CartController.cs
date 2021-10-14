using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RookieEShop.FrontEnd.Services;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using RookieEShop.FrontEnd.Controllers;

namespace RookieEShop.FrontEnd.Controllers
{
	public class CartController : Controller
	{
		private readonly ICartApiClient _cartApiClient;

		public CartController(ICartApiClient cartApiClient)
		{
			_cartApiClient = cartApiClient;
		}

		public IActionResult Index()
		{
			var session = HttpContext.Session;
			string jsonCart = session.GetString("Cart");
			if(jsonCart != null)
			{
				var json = JsonConvert.DeserializeObject<List<CartCreateRequest>> (jsonCart);
				ViewBag.json = json;
				return View();
			}

			return View(NotFound("No item"));
		}

		List<CartCreateRequest> GetAllCart()
		{
			var session = HttpContext.Session;
			string jsoncart = session.GetString("Cart");
			if (jsoncart != null)
			{
				return JsonConvert.DeserializeObject<List<CartCreateRequest>>(jsoncart);
			}
			return new List<CartCreateRequest>();

		}

		public IActionResult AllCart()
		{
			return View();
		}

		[HttpPost]
		public IActionResult UpdateCart(int id, int qty)
		{
			var cart = HttpContext.Session.GetString("cart");

			if(cart != null)
			{
				List<CartCreateRequest> cartList = JsonConvert.DeserializeObject<List<CartCreateRequest>>(cart);
				if(qty > 0) 
				{
					foreach (var i in cartList)
					{
						if (i.productId == id)
						{
							i.Quantity = qty;
						}
					}
					HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartList));
				}
				return Ok();
			}

			return BadRequest();
		}

		public IActionResult DeleteCart(int id)
		{
			var cart = HttpContext.Session.GetString("cart");
			if(cart != null)
			{
				List<CartCreateRequest> listCart = JsonConvert.DeserializeObject<List<CartCreateRequest>>(cart);
				foreach(var i in listCart)
				{
					if(i.productId == id)
					{
						listCart.Remove(i);
					}
				}
				HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));
				return RedirectToAction(nameof(AllCart));
			}

			return RedirectToAction(nameof(Index));
		}

		[Route("/cart", Name ="cart")]
		public IActionResult Cart()
		{
			return View(GetAllCart());
		}
	}
}
