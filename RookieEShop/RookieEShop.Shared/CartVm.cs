using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.Shared
{
	public class CartVm
	{
		public int Id { get; set; }

		public string UserName { get; set; }

		public string ProductName { get; set; }

		public int Quantity { get; set; }
	}
}
