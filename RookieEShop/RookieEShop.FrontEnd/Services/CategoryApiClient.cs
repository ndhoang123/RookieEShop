using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
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
			var response = await client.GetAsync("https://localhost:5001/api/category");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<IList<CategoryVm>>();
		}
	}
}
