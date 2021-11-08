using System;
using System.Collections.Generic;

namespace RookieEShop.BackEnd.Models
{
	public class Ordering
	{
		public int Id { get; set; }

		public DateTime CreatedAt { get; set; }

		public string Address { get; set; }

		public string Name { get; set; }

		public int Phone { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }

		public ICollection<OrderDetail> OrderDetail { get; set; }
	}
}
