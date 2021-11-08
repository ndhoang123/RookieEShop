using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Repositories;
using RookieEShop.Shared;
using System.Collections.Generic;
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

		//public async Task<IEnumerable<OrderVkb>> GetOrderByUserId(string userId)
		//{
		//	return await _orderRepo.GetOrderByUserId(userId);
		//}

		public async Task<bool> AddOrder(Ordering order)
		{
			return await _orderRepo.AddOrder(order);
		}

		public async Task<bool> ChangeStatus(int id, OrderEdit edit)
		{
			return await _orderRepo.ChangeStatus(id, edit);
		}
	}
}
