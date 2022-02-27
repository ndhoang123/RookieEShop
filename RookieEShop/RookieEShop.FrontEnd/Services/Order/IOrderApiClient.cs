using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public interface IOrderApiClient
	{
		Task<IList<OrderVm>> GetHistory();

		Task<bool> CreateOrder(OrderVm cart);

		Task<bool> UpdateOrderStatus(int id, OrderEdit order);
	}
}
