using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using RookieEShop.FrontEnd.Extensions;
using RookieEShop.Shared.Category;

namespace RookieEShop.FrontEnd.Services
{
	public interface ICategoryApiClient
	{
		Task<IList<CategoryVm>> GetCategories();

		Task<IList<ProductVm>> GetProductsByCategories(int categoryId);

		Task<PagedResponseModel<ProductVm>> FilterCategoryList(CategoryPagedQuery categoryPaged, int categoryId);
	}
}
