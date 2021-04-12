using RookieEShop.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public class ProductApiClient : IProductApiClient
	{
		private readonly IHttpClientFactory _factory;

		public ProductApiClient(IHttpClientFactory factory)
		{
			_factory = factory;
		}

		public async Task<IList<ProductVm>> GetProducts()
		{
			var client = _factory.CreateClient();
			var response = await client.GetAsync("https://localhost:5001/api/product");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<IList<ProductVm>>();
		}
		public async Task<ProductVm> GetProductsById(int id)
		{
			var client = _factory.CreateClient();
			var response = await client.GetAsync("https://localhost:5001/api/Product/(Id)?id=" + id.ToString());
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<ProductVm>();
		}
		public async Task<IList<ProductVm>> GetProductsByCategories(int categoryId)
		{
			var client = _factory.CreateClient();
			var response = await client.GetAsync("https://localhost:5001/api/product/(categoryid)?categoryiD=" + categoryId.ToString());
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<IList<ProductVm>>();
		}
	}
}
