using System.ComponentModel.DataAnnotations.Schema;

namespace RookieEShop.BackEnd.Models
{
	public class Ordering
	{
		public int Id { get; set; }

		public int TotalMoney { get; set; }

		public int NumberOfStuff { get; set; }

		public string StatusCart { get; set; }

		[ForeignKey("User")]
		public string UserId { get; set; }

		public User User { get; set; }
		[ForeignKey("Product")]

		public int ProductId { get; set; }

		public Product Product { get; set; }

		public int CartId { get; set; }

		public Cart Cart { get; set; }
	}
}
