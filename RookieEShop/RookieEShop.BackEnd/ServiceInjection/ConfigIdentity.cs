using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.IdentityServer;
using RookieEShop.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.ServiceInjection
{
	public static class ConfigIdentity
	{
		public static IServiceCollection AddIdentitySer (this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
				.AddRoles<IdentityRole>().AddDefaultUI()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddIdentityServer(options =>
			{
				options.Events.RaiseErrorEvents = true;
				options.Events.RaiseInformationEvents = true;
				options.Events.RaiseFailureEvents = true;
				options.Events.RaiseSuccessEvents = true;
				options.EmitStaticAudienceClaim = true;
			})
			   .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
			   .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
			   .AddInMemoryClients(IdentityServerConfig.Clients(configuration))
			   .AddAspNetIdentity<User>()
			   .AddProfileService<CustomProfileService>()
			   .AddDeveloperSigningCredential(); // not recommended for production - you need to store your key material somewhere secure

			return services;
		}
	}
}
