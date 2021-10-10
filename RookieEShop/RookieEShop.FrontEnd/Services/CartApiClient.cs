using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public class CartApiClient : ICartApiClient
	{
		private readonly HttpClient _client;
		private readonly IHttpClientFactory _factory;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CartApiClient(IHttpClientFactory factory, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_factory = factory;
			_client = _factory.CreateClient("Owner");
		}

		public async Task<IList<CartVm>> GetAllCarts()
		{
			var response = await _client.GetAsync("/api/Cart");

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<IList<CartVm>>();
		}

		public async Task<IList<CartVm>> GetDetailCart(int id)
		{
			var response = await _client.GetAsync("/api/Cart/" + id.ToString());

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<IList<CartVm>>();
		}

		public async Task<bool> AddNewItem(CartCreateRequest request)
		{
			var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var response = await _client.PostAsJsonAsync("/api/Cart", request);

			response.EnsureSuccessStatusCode();

			if (response.StatusCode.Equals(201))
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public async Task<bool> UpdateItem(int id, CartEdit edit)
		{
			var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var response = await _client.PutAsJsonAsync("/api/Cart/" + id.ToString(), edit);

			response.EnsureSuccessStatusCode();

			if (response.StatusCode.Equals(204))
			{
				return true;
			}

			else
			{
				return false;
			}
		}
	}
}
