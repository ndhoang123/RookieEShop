using System;
using System.ComponentModel.DataAnnotations;

namespace RookieEShop.BackEnd.Models
{
	public class OrderTracking
	{
		public int Id { get; set; }

		[StringLength(100)]
		public string Status { get; set; }

		public DateTime Updated { get; set; }

		[StringLength(450)]
		public string OrderInformation { get; set; }

		public int OrderDetailId { get; set; }

		public OrderDetail OrderDetail { get; set; }
	}
}
