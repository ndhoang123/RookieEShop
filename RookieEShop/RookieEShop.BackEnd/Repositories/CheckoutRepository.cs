using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public class CheckoutRepository : ICheckOutRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public CheckoutRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<DeliveryInformationVm> GetShipping(string userId)
		{
			var model = new DeliveryInformationVm();

			model.ExistingShippingAddress = await _dbContext.Orderings
													.Where(x => x.UserId.Equals(userId))
													.Select(x => new OrderAddressVm
													{
														ContactName = x.ShippingAddress.Name,
														HomeAddress = x.ShippingAddress.Address,
														OrderCity = x.ShippingAddress.City,
														OrderDistrict = x.ShippingAddress.District,
														PhoneNumber = x.ShippingAddress.Phone,
														Id = x.ShippingAddress.Id
													})
													.AsNoTracking()
													.Distinct()
													.ToListAsync();
			return model;
		}
	}
}
