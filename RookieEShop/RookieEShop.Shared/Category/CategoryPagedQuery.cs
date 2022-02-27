using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.Shared.Category
{
    public class CategoryPagedQuery
    {
        public int Limit { get; set; } = 24;

        public int Page { get; set; } = 1;

        public string[,] Price {get; set;}

        public string[] Rating {get; set;}

        public string SortingColumn {get; set;} = "Price";

        public int SortingQuantity {get; set;} = 24;
    }
}