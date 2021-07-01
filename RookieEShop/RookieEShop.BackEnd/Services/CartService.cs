using RookieEShop.BackEnd.Repositories;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public class CartService : ICartService
	{
		private readonly ICartRepository _cartRepository;

		public CartService(ICartRepository cartRepository)
		{
			_cartRepository = cartRepository;
		}

		public async Task<IEnumerable<CartVm>> GetAllList()
		{
			return await _cartRepository.GetAllCart();
		}

		public async Task<CartVm> GetDetailList(int id)
		{
			return await _cartRepository.GetDetailCart(id);
		}
	}
}
