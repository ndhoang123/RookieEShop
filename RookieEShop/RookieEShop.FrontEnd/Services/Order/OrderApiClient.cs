using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public class OrderApiClient : IOrderApiClient
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IHttpClientFactory _httpClientFactory;
		public OrderApiClient(IHttpClientFactory httpClientFactory, 
			IHttpContextAccessor httpContextAccessor, HttpClient client)
		{
			_httpClientFactory = httpClientFactory;
			_httpContextAccessor = httpContextAccessor;
			_client = _httpClientFactory.CreateClient("owner");
		}

		public async Task<bool> CreateOrder(OrderVm cart)
		{
			var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("sub");

			cart.UserId = userId;

			var response = await _client.PostAsJsonAsync("api/Order", cart);

			response.EnsureSuccessStatusCode();

			if (response.ReasonPhrase.Equals("Created"))
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public async Task<IList<OrderVm>> GetHistory()
		{
			var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("sub");

			var response = await _client.GetAsync("api/Order/" + userId);

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<IList<OrderVm>>();
		}

		public async Task<bool> UpdateOrderStatus(int id, OrderEdit order)
		{
			var response = await _client.PutAsJsonAsync("/api/Order/" + id.ToString(), order);

			response.EnsureSuccessStatusCode();

			if (response.ReasonPhrase.Equals("No Content"))
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
