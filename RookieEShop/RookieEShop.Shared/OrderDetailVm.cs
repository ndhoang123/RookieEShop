using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.Shared
{
	public class OrderDetailVm
	{
		public int Id { get; set; }

		public decimal Price { get; set; }

		public decimal? Discount { get; set; }

		public int Qty { get; set; }

		public int OrderId { get; set; }

		public int ProductId { get; set; }
	}
}
