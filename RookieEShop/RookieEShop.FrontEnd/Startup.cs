using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using RookieEShop.FrontEnd.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace RookieEShop.FrontEnd
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

			services.AddHttpClient();

			JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

			
			services.AddHttpContextAccessor();

			services.AddAuthentication(options =>
			{
				options.DefaultScheme = "Cookies";
				options.DefaultChallengeScheme = "oidc";
			})
				.AddCookie("Cookies")
				.AddOpenIdConnect("oidc", options =>
				{
					options.Authority = "https://rookieeshop.azurewebsites.net/";
					//options.RequireHttpsMetadata = false;
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
			services.AddHttpClient("owner", configureClient =>
				{
					configureClient.BaseAddress = new Uri("https://rookieeshop.azurewebsites.net/");
				}).ConfigureHttpClient(async (serProvider, Httpclient)=>
				{
					var httpContext = serProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
					var accessToken = await httpContext.GetTokenAsync("access_token");
					if (accessToken != null)
						Httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
				});

			services.AddTransient<IProductApiClient, ProductApiClient>();
			services.AddTransient<ICategoryApiClient, CategoryApiClient>();
			services.AddTransient<IRatingApiClient, RatingApiClient>();

			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
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

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
