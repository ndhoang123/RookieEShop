using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace RookieEShop.BackEnd.ServiceInjection
{
	public static class ConfigSwagger
	{
		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rookie Shop API", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Type = SecuritySchemeType.OAuth2,
					Flows = new OpenApiOAuthFlows
					{
						AuthorizationCode = new OpenApiOAuthFlow
						{
							TokenUrl = new Uri("/connect/token", UriKind.Relative),
							AuthorizationUrl = new Uri("/connect/authorize", UriKind.Relative),
							Scopes = new Dictionary<string, string> { { "rookieEShop.API", "Rookie Shop API" } }
						},
					},
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
						},
						new List<string>{ "rookieEShop.API" }
					}
				});
			});

			return services;
		}
	}
}
