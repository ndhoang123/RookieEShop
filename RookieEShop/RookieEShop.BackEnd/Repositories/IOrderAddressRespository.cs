using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public interface IOrderAddressRespository
	{
		public Task<OrderAddressVm> GetCurrentAddress(long id);
	}
}
