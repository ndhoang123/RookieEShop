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

		public async Task<bool> PostCheckout(OrderVm order)
		{
			var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var response = await _client.PostAsJsonAsync("/api/Order", order);

			response.EnsureSuccessStatusCode();

			if (response.ReasonPhrase.Equals("GetCheckout"))
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
