using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public interface IOrderAddressService
	{
		public Task<OrderAddressVm> GetCurrentAddress(long id);
	}
}
