using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookieEShop.BackEnd.Models
{
	public class OrderDetail
	{
		public int Id { get; set; }

		public decimal Price { get; set; }

		public decimal? Discount { get; set; }

		public int Qty { get; set; }

		public int OrderId { get; set; }

		public Ordering Order { get; set; }

		public int ProductId { get; set; }

		public Product Product { get; set; }
	}
}
