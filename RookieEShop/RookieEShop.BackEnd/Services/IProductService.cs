using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public interface IProductService
	{
		public Task<IEnumerable<ProductVm>> ListAllProduct();

		public Task<ProductVm> ListDetailProduct(int id);

		public Task<IEnumerable<ProductVm>> GetProductByCategory(int categoryiD);

		public Task<bool> CreateProduct(Product product);

		public Task<bool> EditProduct(int id, Product product);

		public Task<bool> DeleteProduct(int id);
	}
}
