using System;
using System.Collections.Generic;

namespace RookieEShop.Shared
{
	public class OrderVm
	{
		public int OrderId { get; set; }

		public string OrderName { get; set; }

		public string StatusCart { get; set; }

		public int TotalMoney { get; set; }

		public string UserId { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime BillDay { get; set; }

		public DateTime DeliveryDay { get; set; }

		public long ShippingAddressId { get; set; }

		public string? Note { get; set; }

		public string? Coupon { get; set; }

		public string ShippingMethod { get; set; }

		public decimal ShippingFee { get; set; }

		public string PaymentMethod { get; set; }

		public decimal PaymentFee { get; set; }

		public decimal TaxAmount { get; set; }

		public ICollection<OrderDetailVm> OrderDetail { get; set; }

		public OrderAddressVm OrderAddressForm { get; set; }

		public ICollection<OrderTrackingVm> OrderTracking { get; set; }
	}
}
