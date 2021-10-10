using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RookieEShop.FrontEnd.Services;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

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

		public async Task<IActionResult> AllCart()
		{
			//var cart = await _cartApiClient.GetAllCarts();
			//return View(cart);

			var cart = HttpContext.Session.GetString("cart");
			if(cart != null)
			{
				List<CartCreateRequest> cartList = JsonConvert.DeserializeObject<List<CartCreateRequest>>(cart);
				for(int i = 0; i < cartList.Count; i++)
				{
					ViewBag.carts = cartList;
					return View();
				}
			}

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> DetailCart(int cartId)
		{
			var response = await _cartApiClient.GetDetailCart(cartId);
			return View(response);
		}

		[Authorize]
		//[HttpPost("[controller]/{id}")]
		public async Task<IActionResult> AddItem(int productId)
		{
			var cart = HttpContext.Session.GetString("Cart");

			if (cart == null)
			{
				List<CartCreateRequest> item = new List<CartCreateRequest>()
				{
					new CartCreateRequest
					{
						productId = productId,
						Quantity = 1,
						Price = 0
					}
				};
				HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(item));
			}

			else
			{
				List<CartCreateRequest> dataCart = JsonConvert.DeserializeObject<List<CartCreateRequest>>(cart);
				bool check = true;
				for(var i = 0; i < dataCart.Count; i++)
				{
					if(dataCart[i].productId == productId)
					{
						dataCart[i].Quantity++;
						dataCart[i].Price = dataCart[i].Price + dataCart[i].Price;
						check = false;
					}
				}

				if (check)
				{
					dataCart.Add(new CartCreateRequest
					{
						productId = productId,
						Quantity = 1,
						Price = 0
					});
				}

				HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
			}

			//CartCreateRequest request = new CartCreateRequest
			//{
			//	productId = productId,
			//	Quantity = 1,
			//	Price = Price
			//};

			//var addItem = await _cartApiClient.AddNewItem(request);

			//if (!addItem)
			//{
			//	return NoContent();
			//}

			return RedirectToAction("Details", "Cart", new { id = productId });
		}
	}
}
