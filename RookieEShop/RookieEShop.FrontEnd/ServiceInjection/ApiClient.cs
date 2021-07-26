using Microsoft.Extensions.DependencyInjection;
using RookieEShop.FrontEnd.Services;

namespace RookieEShop.FrontEnd.ServiceInjection
{
	public static class ApiClient
	{
		public static IServiceCollection AddApiClient(this IServiceCollection services)
		{
			services.AddTransient<IProductApiClient, ProductApiClient>();
			services.AddTransient<ICategoryApiClient, CategoryApiClient>();
			services.AddTransient<IRatingApiClient, RatingApiClient>();
			services.AddTransient<ICartApiClient, CartApiClient>();
			return services;
		}
	}
}
