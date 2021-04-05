using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RookieEShop.Shared
{
	public class CategoryCreateRequest
	{
		[Required]
		public string Name { get; set; }
	}
}
