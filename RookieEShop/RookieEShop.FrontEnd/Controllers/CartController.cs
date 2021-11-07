using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RookieEShop.FrontEnd.Services;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Controllers
{
	public class CartController : Controller
	{
		private readonly ICartApiClient _cartApiClient;
		private readonly IOrderApiClient _orderApiClient;

		public CartController(ICartApiClient cartApiClient, IOrderApiClient orderApiClient)
		{
			_cartApiClient = cartApiClient;
			_orderApiClient = orderApiClient;
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

		[Route("/ordering", Name = "ordering")]
		public IActionResult Ordering()
		{
			var cart = GetAllCart();
			return View(cart);
		}

		[Route("/cart", Name ="cart")]
		public IActionResult Cart()
		{
			return View(GetAllCart());
		}

		[Authorize]
		[Route("/checkout", Name ="checkout")]
		[HttpPost("[controller]")]
		public async Task<IActionResult> Checkout(string lname, string fname, string city,
			string state, string houseadd, string email, string phone)
		{
			var order = CreateCheckout(lname, fname, city, state, houseadd, email, phone);
			var isDone = await _orderApiClient.CreateOrder(order);
			if (!isDone)
			{
				DeleteCart();
				return View();
			}
			return View();
		}

		private OrderVm CreateCheckout(string lname, string fname, string city,
			string state, string houseadd, string email, string phone)
		{
			var cart = GetAllCart();

			var order = new OrderVm
			{
				ClientName = fname + " " + lname,
				Phone = Convert.ToInt32(phone),
				Address = houseadd + " " + state + " " + city,
				CreatedAt = DateTime.Now,
				Status = "Processing"
			};


			return order;
		}
	}
}
