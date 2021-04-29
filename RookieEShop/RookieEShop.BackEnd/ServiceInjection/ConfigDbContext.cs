using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RookieEShop.BackEnd.Data;

namespace RookieEShop.BackEnd.ServiceInjection
{
	public static class ConfigDbContext
	{
		public static IServiceCollection AddDbContextI(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection")));
			return services;
		}
	}
}
