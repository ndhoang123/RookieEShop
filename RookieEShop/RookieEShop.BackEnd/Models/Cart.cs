﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Models
{
	public class Cart
	{
		public int Id { get; set; }

		[ForeignKey("User")]
		public string UserId { get; set; }

		public User User { get; set; }
		[ForeignKey("Product")]

		public int ProductId { get; set; }

		public Product Product { get; set; }

		public Ordering Order { get; set; }

		public int Quantity { get; set; }
	}
}
