using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Repositories;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepo;

		public OrderService(IOrderRepository orderRepo)
		{
			_orderRepo = orderRepo;
		}

		public async Task<bool> AddOrder(Ordering order)
		{
			return await _orderRepo.AddOrder(order);
		}
	}
}
