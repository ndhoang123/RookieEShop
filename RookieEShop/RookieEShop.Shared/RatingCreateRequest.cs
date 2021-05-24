using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.Shared
{
	public class RatingCreateRequest
	{
		public int Val { get; set; }

		public string Comment { get; set; }

		public int ProductId { get; set; }
	}
}
