﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace RookieEShop.FrontEnd.ServiceInjection
{
	public static class Auth2
	{
		public static IServiceCollection AddAuth2(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = "Cookies";
				options.DefaultChallengeScheme = "oidc";
			})
				.AddCookie("Cookies")
				.AddOpenIdConnect("oidc", options =>
				{
					options.Authority = configuration["HostAzureUrls:Host"];
					options.RequireHttpsMetadata = true;
					options.GetClaimsFromUserInfoEndpoint = true;

					options.ClientId = "mvc";
					options.ClientSecret = "secret";
					options.ResponseType = "code";

					options.SaveTokens = true;

					options.Scope.Add("openid");
					options.Scope.Add("profile");
					options.Scope.Add("rookieEShop.API");

					options.TokenValidationParameters = new TokenValidationParameters
					{
						NameClaimType = "name",
						RoleClaimType = "role"
					};
				});

			return services;
		}
	}
}