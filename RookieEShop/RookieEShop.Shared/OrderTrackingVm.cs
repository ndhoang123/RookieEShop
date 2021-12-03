using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.Shared
{
	public class OrderTrackingVm
	{
		public string Status { get; set; }

		public DateTime Updated { get; set; }

		public string OrderInformation { get; set; }
	}
}
