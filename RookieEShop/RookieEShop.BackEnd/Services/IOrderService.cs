using RookieEShop.BackEnd.Models;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public interface IOrderService
	{
		Task<bool> AddOrder(Ordering order);
	}
}
