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

		public DbSet<OrderDetail> OrderDetails { get; set; }

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

			modelBuilder.Entity<Ordering>().HasKey(x => new { x.Id });

			modelBuilder.Entity<Ordering>()
				.HasOne<User>(s => s.User)
				.WithMany(x => x.Orderings)
				.HasForeignKey(x => x.UserId);

			modelBuilder.Entity<OrderDetail>()
				.Property(x => x.OrderName)
				.HasComputedColumnSql("N'RE'+ RIGHT('0000000'+CAST(OrderDetailId AS VARCHAR(7)),7)");

			modelBuilder.Entity<OrderDetail>()
				.HasOne<Product>(s => s.Product)
				.WithMany(x => x.OrderDetails)
				.HasForeignKey(x => x.ProductId);

			modelBuilder.Entity<OrderDetail>()
				.HasOne<Ordering>(s => s.Order)
				.WithMany(s => s.OrderDetail)
				.HasForeignKey(x => x.OrderId);

			modelBuilder.Entity<User>()
				.ToTable("AspNetUsers");
		}
	}
}
