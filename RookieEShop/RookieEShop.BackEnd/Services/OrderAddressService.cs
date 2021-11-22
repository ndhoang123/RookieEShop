using RookieEShop.BackEnd.Repositories;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public class OrderAddressService : IOrderAddressService
	{
		private readonly IOrderAddressRespository _orderAddress;

		public OrderAddressService(IOrderAddressRespository orderAddress)
		{
			_orderAddress = orderAddress;
		}

		public async Task<OrderAddressVm> GetCurrentAddress(long id)
		{
			return await _orderAddress.GetCurrentAddress(id);
		}
	}
}
