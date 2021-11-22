using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public class OrderAddressRepository : IOrderAddressRespository
	{
		private readonly ApplicationDbContext _dbContext;

		public OrderAddressRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<OrderAddressVm> GetCurrentAddress(long id)
		{
			var list = await _dbContext.OrderAddresses.Where(x => x.Id.Equals(id))
												.AsNoTracking()
												.SingleAsync();

			if (list == null)
			{
				return null;
			}

			var listVm = new OrderAddressVm
			{
				HomeAddress = list.Address,
				ContactName = list.Name,
				Id = list.Id,
				OrderCity = list.City,
				OrderDistrict = list.District,
				PhoneNumber = list.Phone,
			};

			return listVm;
		}
	}
}
