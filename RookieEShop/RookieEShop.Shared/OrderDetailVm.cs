using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.Shared
{
	public class OrderDetailVm
	{
		public DateTime DeliveryDate { get; set; }

		public DateTime BillDate { get; set; }

		public decimal Price { get; set; }

		public string StatusCart { get; set; }

		public int Qty { get; set; }

		public List<int> ProductId { get; set; }
	}
}
