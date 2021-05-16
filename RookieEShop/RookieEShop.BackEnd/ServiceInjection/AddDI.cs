using Microsoft.Extensions.DependencyInjection;
using RookieEShop.BackEnd.Repositories;
using RookieEShop.BackEnd.Services;

namespace RookieEShop.BackEnd.ServiceInjection
{
	public static class AddDI
	{
		public static IServiceCollection AddDeInje(this IServiceCollection services)
		{
			services.AddTransient<IStorageService, FileStorageService>();
			services.AddTransient<ICategoryService, CategoryService>();
			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddTransient<IRatingService, RatingService>();
			services.AddTransient<IRatingRepository, RatingRepository>();

			return services;
		}
	}
}
