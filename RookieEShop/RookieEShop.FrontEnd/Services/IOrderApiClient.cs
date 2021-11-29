using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public interface IOrderApiClient
	{
		Task<bool> CreateOrder(OrderVm cart);

		Task<IList<OrderVm>> GetHistory();
	}
}
