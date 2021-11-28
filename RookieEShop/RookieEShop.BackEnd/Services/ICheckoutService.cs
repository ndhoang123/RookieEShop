using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public interface ICheckoutService
	{
		Task<DeliveryInformationVm> GetShipping(string userId);
	}
}
