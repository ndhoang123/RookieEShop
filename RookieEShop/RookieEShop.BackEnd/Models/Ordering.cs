using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookieEShop.BackEnd.Models
{
	public class Ordering
	{
		public int Id { get; set; }

		public int TotalMoney { get; set; }

		public int NumberOfStuff { get; set; }

		public DateTime CreatedAt { get; set; }

		public string Address { get; set; }

		public string Name { get; set; }

		public int Phone { get; set; }

		public string StatusCart { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }
	}
}
