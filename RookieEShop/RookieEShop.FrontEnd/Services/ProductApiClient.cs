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
			//var response = await client.GetAsync("https://rookieeshop.azurewebsites.net/api/product");
			var response = await client.GetAsync("https://localhost:44305/api/Product");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<IList<ProductVm>>();
		}
		public async Task<ProductVm> GetProductsById(int id)
		{
			var client = _factory.CreateClient();
			//var response = await client.GetAsync("https://rookieeshop.azurewebsites.net/api/Product/" + id.ToString());
			var response = await client.GetAsync("https://localhost:44305/api/Product/" + id.ToString());
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<ProductVm>();
		}
		public async Task<IList<ProductVm>> GetProductsByCategories(int categoryId)
		{
			var client = _factory.CreateClient();
			//var response = await client.GetAsync("https://rookieeshop.azurewebsites.net/api/product/(categoryid)?categoryiD=" + categoryId.ToString());
			var response = await client.GetAsync("https://localhost:44305/api/Product/(categoryid)?categoryiD=" + categoryId.ToString());
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<IList<ProductVm>>();
		}
		public async Task<double> GetAverageResult(int categoryId)
		{
			var client = _factory.CreateClient();
			var response = await client.GetAsync("https://localhost:44305/api/Rating/" + categoryId.ToString());
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<double>();
		}
	}
}
