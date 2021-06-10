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

		public async Task<IEnumerable<ProductVm>> ListAllProduct()
		{
			var productList = await _context.Products
				.Where(x => x.IsDisableProduct.Equals(false))
				.AsNoTracking()
				.ToListAsync();

			var productListVm = productList.Select(x => new ProductVm
			{
				Id = x.Id,
				Name = x.Name,
				Price = x.Price,
				Author = x.Author,
				Year = x.Year,
				Publisher = x.Publisher,
				Description = x.Description,
				ThumbnailImageUrl = _storageService.GetFileUrl(x.ImageFileName)
			})
				.ToList();

			return productListVm;
		}

		public async Task<ProductVm> ListDetailProduct(int id)
		{
			var detailProduct = await _context.Products.FindAsync(id);
			
			if(detailProduct == null)
			{
				return null;
			}

			var ProductVm = new ProductVm
			{
				Id = detailProduct.Id,
				Description = detailProduct.Description,
				Name = detailProduct.Name,
				Price = detailProduct.Price,
				Publisher = detailProduct.Publisher,
				Year = detailProduct.Year,
				Author = detailProduct.Author,
				ThumbnailImageUrl = _storageService.GetFileUrl(detailProduct.ImageFileName)
			};

			return ProductVm;
		}

		public async Task<IEnumerable<ProductVm>> GetProductByCategory(int categoryiD)
		{
			var product = await _context.Products.Where(x => x.CategoryID == categoryiD)
				.AsNoTracking()				
				.ToListAsync();

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
			detailProduct.IsDisableProduct = product.IsDisableProduct;

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

			product.IsDisableProduct = true;

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
