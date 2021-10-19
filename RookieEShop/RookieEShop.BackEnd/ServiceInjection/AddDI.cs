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
			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<ICartService, CartService>();
			services.AddTransient<ICartRepository, CartRepository>();
			services.AddTransient<IOrderService, OrderService>();
			services.AddTransient<IOrderRepository, OrderRepository>();

			return services;
		}
	}
}
