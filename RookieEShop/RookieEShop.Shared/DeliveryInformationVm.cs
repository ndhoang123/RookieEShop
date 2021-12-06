using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.Shared
{
	public class DeliveryInformationVm
	{
		public IList<OrderAddressVm> ExistingShippingAddress { get; set; } = new List<OrderAddressVm>();

		public long ShippingAddressId { get; set; }

		public string ShippingMethod { get; set; }

		public OrderAddressVm NewAddress { get; set; }

		public string OrderNote { get; set; }
	}
}
