using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RookieEShop.FrontEnd.ServiceInjection
{
	public static class HttpClient
	{
		public static IServiceCollection AddConfigHttpClient(this IServiceCollection services, IConfiguration configuration)
		{
			Startup.HostUri = configuration["HostVSCode:Host"].ToString();

			services.AddHttpContextAccessor();

			services.AddHttpClient("owner", (configureClient) =>
			{
				configureClient.BaseAddress = new Uri(Startup.HostUri);
			})

				.ConfigurePrimaryHttpMessageHandler(serProvider =>
				{
					var clientHandler = new HttpClientHandler
					{
						ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true,
					};
					return clientHandler;
				})

				.ConfigureHttpClient(async (serProvider, Httpclient) =>
				{
					var httpContext = serProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;

					var accessToken = await httpContext.GetTokenAsync("access_token");

					if (accessToken != null)
						Httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
				});

			return services;
		}
	}
}
