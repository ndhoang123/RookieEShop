using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public class CartRepository : ICartRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public CartRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<CartVm>> GetAllCart()
		{
			var listAllCart = await _dbContext.Carts.Select(x => new CartVm
			{
				Id = x.Id,
				ProductName = x.Product.Name,
				UserName = x.User.UserName
			})
				.AsNoTracking()
				.ToListAsync();

			return listAllCart;
		}

		public async Task<CartVm> GetDetailCart(int id)
		{
			var detailCart = await _dbContext.Carts.Select(x => new CartVm
			{
				Id = x.Id,
				ProductName = x.Product.Name,
				UserName = x.User.UserName
			})
				.Where(item => item.Id.Equals(id))
				.AsNoTracking()
				.SingleAsync();

			return detailCart;
		}

		public async Task<bool> CreateCart(Cart cart)
		{
			cart.Quantity = countDuplicatedItem(cart.ProductId);

			_dbContext.Carts.Add(cart);

			if (await _dbContext.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public async Task<bool> DeleteCart(int id)
		{
			var cart = await _dbContext.Carts
								.Where(x => x.Id.Equals(id))
								.AsNoTracking()
								.SingleAsync();

			if (cart == null) return false;

			_dbContext.Carts.Remove(cart);

			if(await _dbContext.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		private int countDuplicatedItem(int productId)
		{
			var duplicatedItem = _dbContext.Carts
									.Where(x => x.ProductId.Equals(productId))
									.AsNoTracking()
									.Count();

			if (duplicatedItem > 0)
			{
				return duplicatedItem + 1;
			}
			
			return 1;
		}
	}
}
