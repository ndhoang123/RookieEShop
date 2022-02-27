using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Services
{
	public interface ICheckoutApiClient
	{
		Task<DeliveryInformationVm> GetShipping();
	}
}
