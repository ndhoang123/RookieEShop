using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RookieEShop.FrontEnd.Services;
using RookieEShop.Shared;
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
			var cart = await _cartApiClient.GetAllCarts();
			return View(cart);
		}

		public async Task<IActionResult> DetailCart(int cartId)
		{
			var response = await _cartApiClient.GetDetailCart(cartId);
			return View(response);
		}

		[Authorize]
		[HttpPost("[controller]/{id}")]
		public async Task<IActionResult> AddItem(int productId, int quantity, decimal Price)
		{
			CartCreateRequest request = new CartCreateRequest
			{
				productId = productId,
				Quantity = quantity,
				Price = Price
			};

			var addItem = await _cartApiClient.AddNewItem(request);

			if (!addItem)
			{
				return NoContent();
			}

			return RedirectToAction("Details", "Cart", new { id = productId });
		}
	}
}
