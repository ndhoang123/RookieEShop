using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RookieEShop.FrontEnd.Models;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private IHttpClientFactory _factory;

		public HomeController(ILogger<HomeController> logger, IHttpClientFactory factory)
		{
			_logger = logger;
			_factory = factory;
		}

		public async Task< IActionResult> Index()
		{
			HttpClient client = _factory.CreateClient();
			string baseUrl = "https://localhost:5001";
			//client.BaseAddress = new Uri("https://localhost:5001/");
			string endpoint = "/api/Product";
			string url = baseUrl + endpoint;
			var reponse = await client.GetAsync(url);
			string jsonData = await reponse.Content.ReadAsStringAsync();
			List<ProductVm> data = JsonSerializer.Deserialize<List<ProductVm>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
		
			return View(data);
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
