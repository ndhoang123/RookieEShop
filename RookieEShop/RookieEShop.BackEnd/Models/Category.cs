using System.Collections.Generic;

namespace RookieEShop.BackEnd.Models
{
	public class Category
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public IList<Product> products { get; set; }
	}
}
