using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookieEShop.BackEnd.Models
{
	public class Product
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public string Author { get; set; }

		public int Year { get; set; }

		public string Publisher { get; set; }

		public string Description { get; set; }

		public string ImageFileName { get; set; }

		public bool IsDisableProduct { get; set; }

		[ForeignKey("Category")]
		public int CategoryID { get; set; }

		public Category Category { get; set; }

		public ICollection<Rating> Rating { get; set; }
	}
}
