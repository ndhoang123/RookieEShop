using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.IdentityServer;
using RookieEShop.BackEnd.Models;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System;

namespace RookieEShop.BackEnd
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));

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
			   .AddInMemoryClients(IdentityServerConfig.Clients)
			   .AddAspNetIdentity<User>()
			   .AddDeveloperSigningCredential(); // not recommended for production - you need to store your key material somewhere secure


			services.AddControllersWithViews();


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
							Scopes = new Dictionary<string, string> { { "rookieshop.api", "Rookie Shop API" } }
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
						new List<string>{ "rookieshop.api" }
					}
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseIdentityServer();
			app.UseAuthorization();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.OAuthClientId("swagger");
				c.OAuthClientSecret("secret");
				c.OAuthUsePkce();
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rookie Shop API V1");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
