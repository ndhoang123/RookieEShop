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
		private readonly ICheckoutApiClient _checkoutApiClient;

		public CartController(ICartApiClient cartApiClient, IOrderApiClient orderApiClient,
			ICheckoutApiClient checkoutApiClient)
		{
			_cartApiClient = cartApiClient;
			_orderApiClient = orderApiClient;
			_checkoutApiClient = checkoutApiClient;
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
		public async Task<IActionResult> Ordering()
		{
			var order = await _checkoutApiClient.GetShipping();
			return View(order);
		}

		[Route("/cancelOrder", Name ="cancelOrder")]
		public IActionResult CancelOrder()
		{
			return Redirect("~/");
		}

		[Route("/cart", Name ="cart")]
		public IActionResult Cart()
		{
			return View(GetAllCart());
		}


		[Route("/checkout", Name = "checkout")]
		[HttpPost("[controller]")]
		public IActionResult Checkout(DeliveryInformationVm model) // The function cant get the value from the view
		{
			var session = HttpContext.Session;

			string jsonModel = JsonConvert.SerializeObject(model);

			session.SetString("model", jsonModel);

			return RedirectToAction("Payment");
		}

		[Route("/payment", Name = "payment")]
		public IActionResult Payment()
		{
			return View();
		}

		
		[HttpPost("paymenthandle")]
		public async Task<IActionResult> PaymentHandle(string Shippingmethod, string Paymentmethod)
		{
			string jsoncart = HttpContext.Session.GetString("model");
			var model = new DeliveryInformationVm();
			var cart = GetAllCart();
			if (jsoncart != null)
			{
				model = JsonConvert.DeserializeObject<DeliveryInformationVm>(jsoncart);
			}

			var order = new OrderVm
			{
				BillDay = DateTime.Now,
				CreatedAt = DateTime.Now,
				DeliveryDay = Shippingmethod.Equals("30000") ? DateTime.Now.AddHours(2) : DateTime.Now.AddDays(3),
				ShippingFee = Int32.Parse(Shippingmethod),
				ShippingMethod = Shippingmethod.Equals("30000") ? "Faster" : "Standard",
				PaymentMethod = Paymentmethod,
				PaymentFee = Paymentmethod.Equals("COD") ? 0 : 10000,
				Coupon = null,
				Note = null,
				StatusCart = "New",
				TaxAmount = 0.1M,
				ShippingAddressId = model.ShippingAddressId,
				OrderAddressForm = model.NewAddress,
				OrderDetail = new List<OrderDetailVm>()
			};

			foreach(var i in cart)
			{
				order.OrderDetail.Add(new OrderDetailVm
				{
					ProductId = i.ProductId,
					Discount = 0,
					Price = i.Price,
					Qty = i.Quantity
				});
			}

			var payment = await _orderApiClient.CreateOrder(order);

			if (!payment)
			{
				return RedirectToAction("Success");
			}


			return RedirectToAction("Success");
		}

		[Route("/success", Name = "success")]
		public IActionResult Success()
		{
			return View();
		}
	}
}
