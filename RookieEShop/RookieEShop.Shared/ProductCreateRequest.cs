using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieEShop.Shared
{
	public class ProductCreateRequest
	{
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public IFormFile ThumbnailImage { get; set; }

        public int BrandId { get; set; }

        public IList<int> CategoryIds { get; set; }
    }
}
