using Microsoft.Extensions.DependencyInjection;

namespace RookieEShop.BackEnd.ServiceInjection
{
	public static class ConfigSecurity
	{
		public static IServiceCollection AddAuthor(this IServiceCollection services)
		{
			services.AddAuthorization(options =>
			{
				options.AddPolicy("Bearer", policy =>
				{
					policy.AddAuthenticationSchemes("Bearer");
					policy.RequireAuthenticatedUser();
				});
			});
			return services;
		}

		public static IServiceCollection AddAuthen(this IServiceCollection services)
		{
			services.AddAuthentication()
				.AddLocalApi("Bearer", option =>
				{
					option.ExpectedScope = "rookieEShop.API";
				});
			return services;
		}
	}
}
