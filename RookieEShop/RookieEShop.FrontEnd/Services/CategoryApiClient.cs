using RookieEShop.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public class CategoryApiClient : ICategoryApiClient
	{
		private readonly IHttpClientFactory _factory;

		public CategoryApiClient(IHttpClientFactory factory)
		{
			_factory = factory;
		}
		public async Task<IList<CategoryVm>> GetCategories()
		{
			var client = _factory.CreateClient();
			var response = await client.GetAsync("https://localhost:44305/api/category");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<IList<CategoryVm>>();
		}
		public async Task<IList<CategoryVm>> GetCategoriesById(int id)
		{
			var client = _factory.CreateClient();
			var response = await client.GetAsync("https://localhost:44305/api/category/" + id.ToString());
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<IList<CategoryVm>>();
		}
	}
}
