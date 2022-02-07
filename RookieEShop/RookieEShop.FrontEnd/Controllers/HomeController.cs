using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RookieEShop.FrontEnd.Models;
using RookieEShop.FrontEnd.Services;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProductApiClient _productClient;
		private readonly ICategoryApiClient _categoryApiClient;

		public HomeController(ILogger<HomeController> logger, IProductApiClient productClient,
			ICategoryApiClient categoryApiClient)
		{
			_logger = logger;
			_productClient = productClient;
			_categoryApiClient = categoryApiClient;
		}

		public async Task<IActionResult> Index()
		{
			var products = await _productClient.GetProducts();
			var categories = await _categoryApiClient.GetCategories();
			ViewBag.categories = categories;
			var listProduct = (products.Where(x => x.CategoryName.Equals(categories[0].Name))
										.OrderByDescending(x => x.Id)
										.Take(5)).Union(products.Where(x => x.CategoryName.Equals(categories[1].Name))
										.OrderByDescending(x => x.Id)
										.Take(5)).ToList();
			return View(listProduct);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
