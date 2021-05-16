using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Services;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IStorageService _storageService;

		public ProductRepository(ApplicationDbContext context, IStorageService storageService)
		{
			_context = context;
			_storageService = storageService;
		}

		public async Task<IEnumerable<Product>> ListAllProduct()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<Product> ListDetailProduct(int id)
		{
			return await _context.Products.FindAsync(id);
		}

		public async Task<IList<ProductVm>> GetProductByCategory(int categoryiD)
		{
			var product = await _context.Products.Where(x => x.CategoryID == categoryiD).ToListAsync();

			if (product == null)
			{
				return null;
			}

			var ProductVm = product.Select(x => new ProductVm
			{
				Id = x.Id,
				Description = x.Description,
				Name = x.Name,
				Price = x.Price,
				Publisher = x.Publisher,
				Year = x.Year,
				Author = x.Author,
				ThumbnailImageUrl = _storageService.GetFileUrl(x.ImageFileName)
			}).ToList();

			return ProductVm;
		}

		public async Task<bool> CreateProduct(Product product)
		{
			var checkCategory = await _context.Categories.FindAsync(product.CategoryID);

			if (checkCategory == null)
			{
				return false;
			}

			_context.Products.Add(product);

			if (await _context.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public async Task<bool> EditProduct(int id, Product product)
		{
			var detailProduct = await _context.Products.FindAsync(id);

			if (detailProduct == null)
			{
				return false;
			}

			detailProduct.Name = product.Name;
			detailProduct.Price = product.Price;
			detailProduct.Author = product.Author;
			detailProduct.Publisher = product.Publisher;
			detailProduct.Year = product.Year;
			detailProduct.Description = product.Description;

			if (await _context.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public async Task<bool> DeleteProduct(int id)
		{
			var product = await _context.Products.FindAsync(id);

			if (product == null)
			{
				return false;
			}

			_context.Products.Remove(product);

			if (await _context.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}
	}
}
