using RookieEShop.BackEnd.Repositories;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public class CheckoutService : ICheckoutService
	{
		private readonly ICheckOutRepository _ICheckoutRepo;

		public CheckoutService(ICheckOutRepository checkoutRepository)
		{
			_ICheckoutRepo = checkoutRepository;
		}

		public async Task<DeliveryInformationVm> GetShipping(string userId)
		{
			return await _ICheckoutRepo.GetShipping(userId);
		}
 	}
}
