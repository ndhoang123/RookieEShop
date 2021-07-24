using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public interface ICartService
	{
		public Task<IEnumerable<CartVm>> GetAllList();

		public Task<CartVm> GetDetailList(int id);

		public Task<bool> CreateCart(Cart cart);

		public Task<bool> UpdateCart(int id, CartEdit edit);

		public Task<bool> DeleteCart(int id);
	}
}
