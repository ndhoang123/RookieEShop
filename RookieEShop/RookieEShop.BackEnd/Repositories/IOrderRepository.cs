using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public interface IOrderRepository
	{
		Task<bool> AddOrder(Ordering order);

		Task<bool> ChangeStatus(int id, OrderEdit edit);
	}
}
