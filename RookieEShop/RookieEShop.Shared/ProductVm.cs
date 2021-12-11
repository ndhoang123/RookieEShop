using System;
using System.Collections.Generic;
using System.Text;

namespace RookieEShop.Shared
{
	public class ProductVm
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public string Author { get; set; }

		public int Year { get; set; }

		public string Publisher { get; set; }

		public string Description { get; set; }

		public string ThumbnailImageUrl { get; set; }

		public string CategoryName { get; set; }
	}
}
