using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieEShop.Shared
{
    public class ProductCreateRequest
    {
        [Required]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Required Decimal Number")]
        //[RegularExpression(@"^[0-9]+(\.[0-9]{1,100})$", ErrorMessage = "Valid Decimal number with maximum  decimal places.")]
        public decimal Price { get; set; }

        public string Author { get; set; }

        public int Year {get; set;}

        public string Description { get; set; }

        public string Publisher { get; set; }

        public IFormFile ThumbnailImage { get; set; }

        public int CategoryId { get; set; }
    }
}
