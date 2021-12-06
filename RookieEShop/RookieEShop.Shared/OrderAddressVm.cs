using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.Shared
{
	public class OrderAddressVm
	{
		public long Id { get; set; }

		public string ContactName { get; set; }

		public string HomeAddress { get; set; }

		public int PhoneNumber { get; set; }

		public string OrderDistrict { get; set; }

		public string OrderCity { get; set; }
	}
}
