using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.Shared
{
	public class CartCreateRequest
	{
		public int productId { get; set; }

		public int Quantity { get; set; }

		public decimal Price { get; set; }
	}
}
