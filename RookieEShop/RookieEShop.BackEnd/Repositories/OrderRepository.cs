using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public OrderRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<OrderVm>> GetAddressShipping(string userId)
		{
			var listOrder = await _dbContext.Orderings
									.Where(x => x.UserId.Equals(userId))
									.Select(x => new OrderVm
									{
										Address = x.Address,
										ClientName = x.Name,
										Phone = x.Phone,
										CreatedAt = x.CreatedAt
									})
									.AsNoTracking()
									.ToListAsync();
			return listOrder;
		}

		public async Task<bool> AddOrder(Ordering order)
		{
			_dbContext.Orderings.Add(order);

			if(await _dbContext.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public async Task<bool> ChangeStatus(int id, OrderEdit edit)
		{
			if(edit == null)
			{
				return false;
			}

			var order = await _dbContext.Orderings
								.Where(x => x.Id.Equals(id))
								.SingleAsync();

			if(await _dbContext.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}
	}
}
