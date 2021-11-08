using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieEShop.BackEnd.ServiceInjection;

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
			services.AddDbContextI(Configuration);

			services.AddDeInje();

			services.AddIdentitySer(Configuration);

			services.AddAuthor();

			services.AddAuthen();

			services.AddControllersWithViews();

			services.AddRazorPages();

			services.AddSwagger();
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

			app.UseCors(options => {
				options.AllowAnyOrigin();
				options.AllowAnyHeader();
				options.AllowAnyMethod();
			});

			app.UseIdentityServer();
			app.UseAuthorization();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.OAuthClientId("swagger");
				c.OAuthClientSecret("secret");
				c.OAuthUsePkce();
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "RookieEShop");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
				endpoints.MapRazorPages();
			});
		}
	}
}
