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
		private readonly IStorageService _storageService;
		private readonly IProductService _productService;

		public ProductController(IProductService productService, IStorageService storageService)
		{
			_productService = productService;
			_storageService = storageService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<IEnumerable<ProductVm>>> GetProduct()
		{
			var productList = await _productService.ListAllProduct();

			return Ok(productList);
		}
		
		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<ActionResult<ProductVm>> GetProduct(int id)
		{
			var product = await _productService.ListDetailProduct(id);

			if (product == null)
			{
				return NotFound();
			}

			else
			{
				return Ok(product);
			}
		}

		[HttpGet("(categoryid)")]
		[AllowAnonymous]
		public async Task<ActionResult<IEnumerable<ProductVm>>> GetProductByCategory(int categoryId)
		{
			var product = await _productService.GetProductByCategory(categoryId);

			if(product == null)
			{
				return StatusCode(404);
			}

			return Ok(product);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult<ProductVm>> PostProduct([FromForm]ProductCreateRequest productCreateRequest)
		{
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

			var isCreateProduct = await _productService.CreateProduct(product);

			if (isCreateProduct)
			{
				return StatusCode(201);
			}

			else
			{
				return StatusCode(404);
			}
		}

		[HttpPut("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> PutProduct(int id, [FromForm]ProductCreateRequest productRequest)
		{
			if(id <= 0) return StatusCode(400);

			var createProduct = new Product
			{
				Name = productRequest.Name,
				Price = productRequest.Price,
				Author = productRequest.Author,
				Publisher = productRequest.Publisher,
				Year = productRequest.Year,
				Description = productRequest.Description
			};

			var isEditedProduct = await _productService.EditProduct(id, createProduct);

			if (isEditedProduct)
			{
				return StatusCode(204);
			}

			else
			{
				return StatusCode(404);
			}
		}

		[HttpDelete("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var isDeletedProduct = await _productService.DeleteProduct(id);

			if (isDeletedProduct)
			{
				return StatusCode(204); ;
			}

			else
			{
				return StatusCode(404);
			}
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
