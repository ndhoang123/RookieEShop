using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public interface ICartRepository
	{
		Task<IEnumerable<CartVm>> GetAllCart();

		Task<CartVm> GetDetailCart(int id);

		Task<bool> CreateCart(Cart cart);

		Task<bool> DeleteCart(int id);
	}
}
