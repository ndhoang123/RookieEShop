using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Repositories;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<IEnumerable<ProductVm>> ListAllProduct()
		{
			return await _productRepository.ListAllProduct();
		}

		public async Task<ProductVm> ListDetailProduct(int id)
		{
			return await _productRepository.ListDetailProduct(id);
		}

		public async Task<IEnumerable<ProductVm>> GetProductByCategory(int categoryiD)
		{
			return await _productRepository.GetProductByCategory(categoryiD);
		}

		public async Task<bool> CreateProduct(Product product)
		{
			return await _productRepository.CreateProduct(product);
		}

		public async Task<bool> EditProduct(int id, Product product)
		{
			return await _productRepository.EditProduct(id, product);
		}

		public async Task<bool> DeleteProduct(int id)
		{
			return await _productRepository.DeleteProduct(id);
		}
	}
}
