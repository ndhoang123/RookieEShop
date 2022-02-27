using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using RookieEShop.Shared.Paging;

namespace RookieEShop.FrontEnd.Extensions
{
    public static class DataPagerExtensions{
        public static async Task<PagedModel<TModel>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            int page,
            int limit,
            string sortColumnName)
            where TModel : class
        {
            var paged = new PagedModel<TModel>();

            page = (page < 0) ? 1 : page;

            paged.CurrentPage = page;
            paged.PageSize = limit;

            var startRow = (page - 1) * limit;

            if(!string.IsNullOrEmpty(sortColumnName)){
                query = query.OrderBy(sortColumnName);
            }

            paged.Items = await query.Skip(startRow)
                                    .Take(limit)
                                    .ToListAsync();

            paged.TotalItems = await query.CountAsync();
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);
            return paged;
        }
    }
}