using Microsoft.AspNetCore.Mvc;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public interface IOrderApiClient
	{
		Task<bool> CreateOrder(OrderVm cart);
		Task<IList<OrderVm>> GetAddress();
	}
}
