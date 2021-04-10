using Microsoft.AspNetCore.Mvc;
using RookieEShop.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductApiClient _productApiClient;
		public ProductController(IProductApiClient productApiClient)
		{
			_productApiClient = productApiClient;
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
	}
}
