using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.Shared
{
	public class OrderVm
	{
		public string ClientName { get; set; }

		public int Phone { get; set; }

		public string Address { get; set; }

		public int TotalMoney { get; set; }

		public int NumberOfStuff { get; set; }
	}
}
