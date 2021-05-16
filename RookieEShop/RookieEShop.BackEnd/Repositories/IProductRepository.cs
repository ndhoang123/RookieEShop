using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public interface IProductRepository
	{
		public Task<IEnumerable<Product>> ListAllProduct();

		public Task<Product> ListDetailProduct(int id);

		public Task<IList<ProductVm>> GetProductByCategory(int categoryiD);

		public Task<bool> CreateProduct(Product product);

		public Task<bool> EditProduct(int id, Product product);

		public Task<bool> DeleteProduct(int id);
	}
}
