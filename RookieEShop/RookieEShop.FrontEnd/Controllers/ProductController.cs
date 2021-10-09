using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RookieEShop.FrontEnd.Services;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductApiClient _productApiClient;
		private readonly IRatingApiClient _ratingApiClient;
		public ProductController(IProductApiClient productApiClient, IRatingApiClient ratingApiClient)
		{
			_productApiClient = productApiClient;
			_ratingApiClient = ratingApiClient;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> ProductDetail(int productId)
		{
			var products = await _productApiClient.GetProductsById(productId);

			var result = await _productApiClient.GetRatingResult(productId); // call api

			if (result == null) {

				ViewBag.avgRating = 0;

				ViewBag.countReviewer = 0;

				ViewBag.listRating = Enumerable.Empty<RatingVm>();
			}

			else
			{
				ViewBag.avgRating = result.AvgResult;

				ViewBag.countReviewer = result.CountResult;

				ViewBag.listRating = result.ListRating;
			}
			return View(products);
		}

		[Authorize]
		[HttpPost("[controller]/{id}")]
		public async Task<IActionResult> ProductRating(int val, int productId, string comment)
		{
			RatingCreateRequest ratingCreateRequest = new RatingCreateRequest
			{
				Val = val,
				ProductId = productId,
				Comment = comment
			};

			var productRating = await _ratingApiClient.PostRating(ratingCreateRequest);

			if (!productRating)
			{
				return NoContent();
			}

			return RedirectToAction("Details", "Product", new { id = productId });
		}

		[Authorize]
		public async Task<IActionResult> ProductToCart(int id)
		{
			var cart = HttpContext.Session.GetString("Cart");

			var product = await _productApiClient.GetProductsById(id);

			if (cart == null)
			{
				List<CartCreateRequest> item = new List<CartCreateRequest>()
				{
					new CartCreateRequest
					{
						productId = product.Id,
						Quantity = 1,
						Price = product.Price
					}
				};

				HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(item));
			}

			else
			{
				List<CartCreateRequest> dataCart = JsonConvert.DeserializeObject<List<CartCreateRequest>>(cart);
				bool check = true;
				for (var i = 0; i < dataCart.Count; i++)
				{
					if (dataCart[i].productId == product.Id)
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
						productId = product.Id,
						Quantity = 1,
						Price = product.Price
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

			return RedirectToAction("Details", "Cart", new { id = product.Id });
		}
	}
}
