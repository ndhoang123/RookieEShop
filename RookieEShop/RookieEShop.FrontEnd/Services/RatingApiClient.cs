using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public class RatingApiClient : IRatingApiClient
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public RatingApiClient(HttpClient client,
			IHttpContextAccessor httpContextAccessor)
		{
			_client = client;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<bool> PostRating(RatingCreateRequest ratingCreateRequest)
		{
			//var client = _factory.CreateClient();
			var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


			var json = JsonConvert.SerializeObject(ratingCreateRequest);
			var data = new StringContent(json, Encoding.UTF8, "application/json");

			//var response = await _client.PostAsJsonAsync("https://rookieeshop.azurewebsites.net/api/Rating", ratingCreateRequest);
			var response = await _client.PostAsJsonAsync("https://localhost:44305/api/Rating", ratingCreateRequest);

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
