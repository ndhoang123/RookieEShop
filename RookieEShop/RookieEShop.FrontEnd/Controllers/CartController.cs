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
			var cartItem = cart.Find(s => s.ProductId.Equals(id));
			if(cartItem != null)
			{
				cartItem.Quantity = qty;
			}

			SaveCartItem(cart);
			return RedirectToAction(nameof(Cart));
		}

		[Route("/removecart/{productid:int}", Name ="removecart")]
		public IActionResult RemoveCart(int productid)
		{
			var cart = GetAllCart();
			var cartItem = cart.Find(s => s.ProductId.Equals(productid));
			if(cartItem != null)
			{
				cart.Remove(cartItem);
			}

			SaveCartItem(cart);
			return RedirectToAction(nameof(Cart));
		}

		[Route("/deletecart", Name ="deletecart")]
		public IActionResult DeleteCart()
		{
			var session = HttpContext.Session;
			session.Remove("Cart");
			return RedirectToAction(nameof(Cart));
		}

		[Route("/checkout", Name ="checkout")]
		public IActionResult Checkout()
		{
			var cart = GetAllCart();
			return View(cart);
		}

		[Route("/cart", Name ="cart")]
		public IActionResult Cart()
		{
			return View(GetAllCart());
		}
	}
}
