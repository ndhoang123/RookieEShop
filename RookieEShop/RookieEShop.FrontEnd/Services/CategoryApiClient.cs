using RookieEShop.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public class CategoryApiClient : ICategoryApiClient
	{
		private readonly HttpClient _client;
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryApiClient(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
			_client = _httpClientFactory.CreateClient("owner");
		}

		public async Task<IList<CategoryVm>> GetCategories()
		{
			var response = await _client.GetAsync("api/Category");

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<IList<CategoryVm>>();
		}

		public async Task<IList<CategoryVm>> GetCategoriesById(int id)
		{
			var response = await _client.GetAsync("api/Category/" + id.ToString());

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<IList<CategoryVm>>();
		}
	}
}
