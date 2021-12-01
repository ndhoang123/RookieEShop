using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieEShop.BackEnd.Models
{
	public class Ordering
	{
		public Ordering()
		{
			CreatedAt = DateTime.Now;
			BillDate = DateTime.Now;
			DeliveryDate = DateTime.Now.AddDays(3);
			StatusCart = "New";
			isActive = true;
			LastUpdated = DateTime.Now;
		}

		public int Id { get; set; }

		public DateTime CreatedAt { get; set; }

		public string StatusCart { get; set; }

		public DateTime DeliveryDate { get; set; }

		public DateTime BillDate { get; set; }

		public string OrderName { get; set; }

		public decimal TaxAmount { get; set; }

		[StringLength(450)]
#nullable enable
		public string? CouponName { get; set; }

		[StringLength(1000)]
		public string? OrderNote { get; set; }
#nullable disable
		[StringLength(450)]
		public string ShippingMethod { get; set; }

		public decimal ShippingFee { get; set; }

		[StringLength(450)]
		public string PaymentMethod { get; set; }

		public decimal PaymentFee { get; set; }

		public bool isActive { get; set; }

		public DateTime LastUpdated { get; set; }

		public long ShippingAddressId { get; set; }

		public OrderAddress ShippingAddress { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }

		public ICollection<OrderDetail> OrderDetail { get; set; }
	}
}
