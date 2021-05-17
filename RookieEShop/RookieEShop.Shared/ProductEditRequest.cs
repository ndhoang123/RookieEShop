using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieEShop.Shared
{
	public class ProductEditRequest
	{
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public bool IsDisableProduct { get; set; }
    }
}
