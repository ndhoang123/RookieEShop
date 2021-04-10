using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RookieEShop.FrontEnd.Models;
using RookieEShop.FrontEnd.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProductApiClient _productClient;

		public HomeController(ILogger<HomeController> logger, IProductApiClient productClient)
		{
			_logger = logger;
			_productClient = productClient;
		}

		public async Task< IActionResult> Index()
		{
			var products = await _productClient.GetProducts();
			return View(products);
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
