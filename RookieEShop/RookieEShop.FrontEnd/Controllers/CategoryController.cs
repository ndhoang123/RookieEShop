using Microsoft.AspNetCore.Mvc;
using RookieEShop.FrontEnd.Services;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IProductApiClient _productApiClient;

		public CategoryController(IProductApiClient productApiClient)
		{
			_productApiClient = productApiClient;
		}

		public async Task<IActionResult> Index(int id)
		{
			var products = await _productApiClient.GetProductsByCategories(id);
			return View(products); 
		}
	}
}
