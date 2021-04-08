using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public interface ICategoryApiClient
	{
		Task<IList<CategoryVm>> GetCategories();
	}
}
