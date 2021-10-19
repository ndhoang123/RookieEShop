using RookieEShop.BackEnd.Models;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public interface IOrderRepository
	{
		Task<bool> AddOrder(Ordering order);
	}
}
