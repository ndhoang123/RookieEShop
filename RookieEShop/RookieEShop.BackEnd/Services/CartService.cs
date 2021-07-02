using RookieEShop.BackEnd.Models;
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

		public async Task<bool> CreateCart(Cart cart)
		{
			return await _cartRepository.CreateCart(cart);
		}

		public async Task<bool> DeleteCart(int id)
		{
			return await _cartRepository.DeleteCart(id);
		}
	}
}
