using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RookieEShop.Shared
{
	public class BrandCreateRequest
	{
		[Required]
		public string Name { get; set; }
	}
}
