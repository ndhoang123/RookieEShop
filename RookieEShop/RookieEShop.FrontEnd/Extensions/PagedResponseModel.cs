using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.Extensions
{
    public class PagedResponseModel<TModel>
    {
        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public string SortColumnName { get; set; }

        public string SortType { get; set; }

        public IEnumerable<TModel> Items { get; set; }
    }
}