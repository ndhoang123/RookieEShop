using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using RookieEShop.FrontEnd.Services;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hanssens.Net;
using Newtonsoft.Json;

namespace RookieEShop.FrontEnd.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductApiClient _productApiClient;
		private readonly IRatingApiClient _ratingApiClient;
		public const string CARTKEY = "Cart";
		private const string URL = "/Product/ProductDetail?productId=";
		public ProductController(IProductApiClient productApiClient, IRatingApiClient ratingApiClient)
		{
			_productApiClient = productApiClient;
			_ratingApiClient = ratingApiClient;
		}

		public IActionResult Index()
		{
			return View();
		}

		private string AddressPage(string url, int productId)
		{
			return url + productId.ToString();
		}

		public async Task<IActionResult> ProductDetail(int productId)
		{
			var products = await _productApiClient.GetProductsById(productId);

			var result = await _productApiClient.GetRatingResult(productId); // call api

			if (result == null)
			{

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
				return Redirect(AddressPage(URL, productId));
			}

			return Redirect(AddressPage(URL, productId));
		}

		public List<CartCreateRequest> GetCartItem()
		{
			var session = HttpContext.Session;
			string jsoncart = session.GetString("Cart");
			if (jsoncart != null)
			{
				return JsonConvert.DeserializeObject<List<CartCreateRequest>>(jsoncart);
			}
			return new List<CartCreateRequest>();
		}

		public void SaveCartItem(List<CartCreateRequest> listCart)
		{
			var session = HttpContext.Session;
			string jsoncart = JsonConvert.SerializeObject(listCart);
			session.SetString("Cart", jsoncart);
		}


		[Route("addcart/{productId:int}", Name = "addcart")]
		public async Task<IActionResult> ProductToCart([FromRoute] int productId)
		{
			var product = await _productApiClient.GetProductsById(productId);

			if (product == null)
			{
				return NotFound("Have no item. Try it again");
			}

			var cart = GetCartItem();
			var cartItem = cart.Find(s => s.productId.Equals(productId));
			if (cartItem != null)
			{
				cartItem.Quantity++;
			}

			else
			{
				cart.Add(new CartCreateRequest
				{
					Quantity = 1,
					productId = product.Id,
					Price = product.Price
				});
			}

			// Save Cart
			SaveCartItem(cart);
			return Redirect(AddressPage(URL, productId));
		}
	}
}
