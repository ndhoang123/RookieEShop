using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public interface IProductApiClient
	{
		Task<IList<ProductVm>> GetProducts();

		Task<ProductVm> GetProductsById(int id);

		Task<RatingResultVm> GetRatingResult(int categoryId);
	}
}
