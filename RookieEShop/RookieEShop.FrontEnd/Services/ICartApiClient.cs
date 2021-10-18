using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public interface ICartApiClient
	{
		Task<bool> PostCheckout(OrderVm order);
	}
}
