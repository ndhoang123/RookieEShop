using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Services;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize("Bearer")]
	public class ProductController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IStorageService _storageService;
		public ProductController(ApplicationDbContext context, IStorageService storageService)
		{
			_context = context;
			_storageService = storageService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<IEnumerable<ProductVm>>> GetProduct()
		{
			return await _context.Products
				.Select(x => new ProductVm { Id = x.Id,
					Name = x.Name,
					Price = x.Price,
					Author = x.Author,
					Year = x.Year,
					Publisher = x.Publisher,
					Description = x.Description,
					ThumbnailImageUrl = _storageService.GetFileUrl(x.ImageFileName)
				})
				.ToListAsync();
		}
		
		[HttpGet("(Id)")]
		[AllowAnonymous]
		public async Task<ActionResult<ProductVm>> GetProduct(int id)
		{
			var product = await _context.Products.FindAsync(id);

			if (product == null)
			{
				return NotFound();
			}

			var ProductVm = new ProductVm
			{
				Id = product.Id,
				Description = product.Description,
				Name = product.Name,
				Price = product.Price,
				Publisher = product.Publisher,
				Year = product.Year,
				Author = product.Author,
				ThumbnailImageUrl = _storageService.GetFileUrl(product.ImageFileName)
			};

			return ProductVm;
		}
		[HttpGet("(categoryid)")]
		[AllowAnonymous]
		public async Task<ActionResult<IList<ProductVm>>> GetProductByCategory(int categoryiD)
		{
			var product = await _context.Products.Where(x => x.CategoryID == categoryiD).ToListAsync();

			if (product == null)
			{
				return NotFound();
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

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult<ProductVm>> PostProduct([FromForm]ProductCreateRequest productCreateRequest)
		{
			var checkCategory = _context.Categories.Find(productCreateRequest.CategoryId);
			if (checkCategory == null) return BadRequest();
			var product = new Product
			{
				Name = productCreateRequest.Name,
				Price = productCreateRequest.Price,
				Author = productCreateRequest.Author,
				Publisher = productCreateRequest.Publisher,
				Year = productCreateRequest.Year,
				Description = productCreateRequest.Description,
				CategoryID = productCreateRequest.CategoryId
			};

			if (productCreateRequest.ThumbnailImage != null)
			{
				product.ImageFileName = await SaveFile(productCreateRequest.ThumbnailImage);
			}

			_context.Products.Add(product);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetProduct", new { id = product.Id }, null);
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound();
			}

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private async Task<string> SaveFile(IFormFile file)
		{
			var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
			var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
			await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
			return fileName;
		}
		
	}
}
