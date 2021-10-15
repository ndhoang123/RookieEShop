using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RookieEShop.FrontEnd.Services;
using RookieEShop.Shared;
using System.Collections.Generic;

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
			return View();
		}

		List<CartVm> GetAllCart()
		{
			var session = HttpContext.Session;
			string jsoncart = session.GetString("Cart");
			if (jsoncart != null)
			{
				return JsonConvert.DeserializeObject<List<CartVm>>(jsoncart);
			}
			return new List<CartVm>();

		}

		private void SaveCartItem(List<CartVm> ls)
		{
			var session = HttpContext.Session;
			string jsonCart = JsonConvert.SerializeObject(ls);
			session.SetString("Cart", jsonCart);
		}

		public IActionResult AllCart()
		{
			return View();
		}

		[Route("/updatecart", Name ="updatecart")]
		[HttpPost]
		public IActionResult UpdateCart([FromForm] int id, [FromForm] int qty)
		{
			var cart = GetAllCart();
			var cartItem = cart.Find(s => s.Id.Equals(id));
			if(cartItem != null)
			{
				cartItem.Quantity = qty;
			}

			SaveCartItem(cart);
			return RedirectToAction(nameof(Cart));
		}

		[Route("/removecart/{productid:int}", Name ="removecart")]
		public IActionResult DeleteCart(int productid)
		{
			var cart = HttpContext.Session.GetString("Cart");
			if(cart != null)
			{
				List<CartCreateRequest> listCart = JsonConvert.DeserializeObject<List<CartCreateRequest>>(cart);
				foreach(var i in listCart)
				{
					if(i.productId == productid)
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
