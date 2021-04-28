using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public interface IProductApiClient
	{
		Task<IList<ProductVm>> GetProducts();
		Task<ProductVm> GetProductsById(int id);
		Task<IList<ProductVm>> GetProductsByCategories(int categoryId);
		Task<RatingResultVm> GetRatingResult(int categoryId);
	}
}
