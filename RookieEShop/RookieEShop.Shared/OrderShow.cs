using System;

namespace RookieEShop.Shared
{
	public class OrderShow
	{
		public int Id { get; set; }

		public string Status { get; set; }

		public int TotalMoney { get; set;  }

		public DateTime CreatedAt { get; set; }

		public int NumOfStuff { get; set; }

		public string ClientName { get; set; }

		public int Phone { get; set; }

		public string Address { get; set; }
	}
}
