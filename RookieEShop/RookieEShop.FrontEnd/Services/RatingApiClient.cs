using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RookieEShop.Shared;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public class RatingApiClient : IRatingApiClient
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IHttpClientFactory _httpClientFactory;

		public RatingApiClient(
			IHttpContextAccessor httpContextAccessor,
			IHttpClientFactory httpClientFactory)
		{
			_httpContextAccessor = httpContextAccessor;

			_httpClientFactory = httpClientFactory;

			_client = _httpClientFactory.CreateClient("owner");
		}

		public async Task<bool> PostRating(RatingCreateRequest ratingCreateRequest)
		{
			var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			ratingCreateRequest.userId = _httpContextAccessor.HttpContext.User.FindFirstValue("sub");

			var response = await _client.PostAsJsonAsync("api/Rating", ratingCreateRequest);

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
