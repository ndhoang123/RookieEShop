using System;

namespace RookieEShop.Shared
{
	public class OrderVm
	{
		public string ClientName { get; set; }
		
		public int Phone { get; set; }

		public string Address { get; set; }

		public int TotalMoney { get; set; }

		public string UserId { get; set; }

		public DateTime CreatedAt { get; set; }

		public int Id { get; set; }
	}
}
