using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RookieEShop.FrontEnd.Services;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
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
			return View(products);
		}

		[HttpPost("[controller]/{id}")]
		public async Task<IActionResult> ProductRating(int val, int productId, string userId)
		{
			RatingCreateRequest ratingCreateRequest = new RatingCreateRequest
			{
				Val = val,
				ProductId = productId,
				UserId = userId
			};

			var productRating = await _ratingApiClient.PostRating(ratingCreateRequest);

			if (!productRating)
			{
				return NoContent();
			}

			return RedirectToAction("Details", "Product", new { id = productId });
		}
	}
}
