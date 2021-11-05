using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public class OrderApiClient : IOrderApiClient
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IHttpClientFactory _httpClientFactory;
		public OrderApiClient(IHttpClientFactory httpClientFactory, 
			IHttpContextAccessor httpContextAccessor)
		{
			_httpClientFactory = httpClientFactory;
			_httpContextAccessor = httpContextAccessor;
			_client = _httpClientFactory.CreateClient("owner");
		}

		public async Task<bool> CreateOrder(OrderVm cart)
		{
			var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var response = await _client.PostAsJsonAsync("api/Order", cart);

			response.EnsureSuccessStatusCode();

			if (response.ReasonPhrase.Equals("GetRating"))
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
