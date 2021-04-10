using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public interface IProductApiClient
	{
		Task<IList<ProductVm>> GetProducts();
		Task<IList<ProductVm>> GetProductsById(int id);
		Task<IList<ProductVm>> GetProductsByCategories(int categoryId);
	}
}
