using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RookieEShop.Shared;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
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

		[Authorize]
		public async Task<bool> PostRating(RatingCreateRequest ratingCreateRequest)
		{
			ratingCreateRequest.userId = _httpContextAccessor.HttpContext.User.FindFirstValue("sub");

			var json = JsonConvert.SerializeObject(ratingCreateRequest);

			var data = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _client.PostAsync("api/Rating", data);

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
