using Microsoft.Extensions.DependencyInjection;
using RookieEShop.BackEnd.Services;

namespace RookieEShop.BackEnd.ServiceInjection
{
	public static class AddDI
	{
		public static IServiceCollection AddDeInje(this IServiceCollection services)
		{
			services.AddTransient<IStorageService, FileStorageService>();
			return services;
		}
	}
}
