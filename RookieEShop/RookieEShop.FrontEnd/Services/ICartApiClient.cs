using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public interface ICartApiClient
	{
		Task<IList<CartVm>> GetAllCarts();

		Task<IList<CartVm>> GetDetailCart(int id);

		Task<bool> AddNewItem(CartCreateRequest request);

		Task<bool> UpdateItem(int id, CartEdit edit);
	}
}
