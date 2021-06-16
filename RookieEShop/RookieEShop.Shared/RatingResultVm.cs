using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.Shared
{
	public class RatingResultVm
	{
		public double AvgResult { get; set; }

		public int CountResult { get; set; }

		public string Comment { get; set; }

		public IEnumerable<RatingVm> ListRating { get; set; }
	}
}
