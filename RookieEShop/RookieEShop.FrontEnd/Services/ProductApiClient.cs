using RookieEShop.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public class ProductApiClient : IProductApiClient
	{
		private readonly HttpClient _client;
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductApiClient(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;

			_client = _httpClientFactory.CreateClient("owner");
		}

		public async Task<IList<ProductVm>> GetProducts()
		{
			var response = await _client.GetAsync("api/Product");

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<IList<ProductVm>>();
		}

		public async Task<ProductVm> GetProductsById(int id)
		{
			var response = await _client.GetAsync("api/Product/" + id.ToString());

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<ProductVm>();
		}

		public async Task<IList<ProductVm>> GetProductsByCategories(int categoryId)
		{
			var response = await _client.GetAsync("api/Product/(categoryid)?categoryiD=" + categoryId.ToString());

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<IList<ProductVm>>();
		}

		public async Task<RatingResultVm> GetRatingResult(int categoryId)
		{
			var response = await _client.GetAsync("api/Rating/" + categoryId.ToString());

			if (response.IsSuccessStatusCode) { 
				return await response.Content.ReadAsAsync<RatingResultVm>();
			}

			else
			{
				return null;
			}
		}
	}
}
