using Newtonsoft.Json;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public class RatingApiClient : IRatingApiClient
	{
		private readonly IHttpClientFactory _factory;

		public RatingApiClient(IHttpClientFactory factory)
		{
			_factory = factory;
		}

		public async Task<bool> PostRating(RatingCreateRequest ratingCreateRequest)
		{
			var client = _factory.CreateClient();

			var json = JsonConvert.SerializeObject(ratingCreateRequest);

			var data = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:44305/api/Rating", data);

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
