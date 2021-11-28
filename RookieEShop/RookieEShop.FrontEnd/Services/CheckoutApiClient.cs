using Microsoft.AspNetCore.Http;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public class CheckoutApiClient : ICheckoutApiClient
	{
		private readonly HttpClient _client;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CheckoutApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
		{
			_httpClientFactory = httpClientFactory;
			_httpContextAccessor = httpContextAccessor;
			_client = _httpClientFactory.CreateClient("owner");
		}

		public async Task<DeliveryInformationVm> GetShipping()
		{
			var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("sub");

			var response = await _client.GetAsync("api/Checkout/" + userId.ToString());

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<DeliveryInformationVm>();
		}
	}
}
