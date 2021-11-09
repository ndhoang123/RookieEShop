using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookieEShop.BackEnd.Models
{
	public class OrderDetail
	{
		public int OrderDetailId { get; set; }

		public string OrderName { get; set; }

		public DateTime DeliveryDate { get; set; }

		public DateTime BillDate { get; set; }

		public decimal Price { get; set; }

		public decimal? Discount { get; set; }

		public int Qty { get; set; }

		public string StatusCart { get; set; }

		public int OrderId { get; set; }

		public int ProductId { get; set; }

		public Ordering Order { get; set; }

		public Product Product { get; set; }
	}
}
