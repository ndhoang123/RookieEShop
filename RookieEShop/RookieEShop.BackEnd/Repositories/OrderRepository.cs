using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
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
	}
}
