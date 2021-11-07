namespace RookieEShop.Shared
{
	public class Order
	{
		public int Id { get; set; }

		public string Status { get; set; }

		public string TotalMoney { get; set;  }

		public string CreatedAt { get; set; }

		public int NumOfStuff { get; set; }

		public string ClientName { get; set; }

		public int Phone { get; set; }

		public string Address { get; set; }
	}
}
