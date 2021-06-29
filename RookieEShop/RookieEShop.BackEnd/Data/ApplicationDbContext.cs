using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RookieEShop.BackEnd.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public DbSet<Category> Categories { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Rating> Ratings { get; set; }

		public DbSet<Ordering> Orderings { get; set; }

		public DbSet<Cart> Carts { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>()
				.Property(p => p.Price)
				.HasColumnType("decimal");

			modelBuilder.Entity<Product>()
				.HasOne<Category>(s => s.Category)
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.CategoryID);

			modelBuilder.Entity<Rating>()
				.HasOne<Product>(s => s.Product)
				.WithMany(g => g.Rating)
				.HasForeignKey(s => s.ProductId);

			modelBuilder.Entity<Cart>()
				.HasKey(x => new { x.ProductId });

			modelBuilder.Entity<Cart>()
				.HasOne<Product>(x => x.Product)
				.WithMany(s => s.Carts)
				.HasForeignKey(s => s.ProductId);

			modelBuilder.Entity<Cart>()
				.HasOne<User>(s => s.User)
				.WithOne(x => x.Cart)
				.HasForeignKey<Cart>(x => x.UserId);

			modelBuilder.Entity<Ordering>().HasKey(x => new { x.UserId });

			modelBuilder.Entity<Ordering>()
				.HasOne<Cart>(s => s.Cart)
				.WithOne(x => x.Order)
				.HasForeignKey<Ordering>(x => x.CartId);

			modelBuilder.Entity<Ordering>()
				.HasOne<User>(s => s.User)
				.WithMany(x => x.Orderings)
				.HasForeignKey(x => x.UserId);

			modelBuilder.Entity<User>()
				.ToTable("AspNetUsers");
		}
	}
}
