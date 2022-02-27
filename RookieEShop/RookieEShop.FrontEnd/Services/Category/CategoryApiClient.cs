using RookieEShop.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using RookieEShop.Shared.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieEShop.FrontEnd.Extensions;

namespace RookieEShop.FrontEnd.Services
{
	public class CategoryApiClient : ICategoryApiClient
	{
		private readonly HttpClient _client;
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryApiClient(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
			_client = _httpClientFactory.CreateClient("owner");
		}

		public async Task<IList<CategoryVm>> GetCategories()
		{
			var response = await _client.GetAsync("api/Category");

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<IList<CategoryVm>>();
		}
		
		public async Task<IList<ProductVm>> GetProductsByCategories(int categoryId)
		{
			var response = await _client.GetAsync("api/Product/(categoryid)?categoryiD=" + categoryId.ToString());

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<IList<ProductVm>>();
		}

		public async Task<PagedResponseModel<ProductVm>> FilterCategoryList([FromQuery] CategoryPagedQuery categoryPaged, int categoryId){
			var response = await _client.GetAsync("api/Product/(categoryid)?categoryiD=" + categoryId.ToString());

			response.EnsureSuccessStatusCode();

			var categoryList = await response.Content.ReadAsAsync<IList<ProductVm>>();

			var categoryQuery = GetCategoryFilter(categoryList.AsQueryable(), categoryPaged);

			var category = await categoryQuery
									.AsNoTracking()
									.PaginateAsync(
										categoryPaged.Page,
										categoryPaged.Limit,
										categoryPaged.SortingColumn
									);
			
			return new PagedResponseModel<ProductVm>{
				CurrentPage = category.CurrentPage,
				TotalPages = category.TotalPages,
				TotalItems = category.TotalItems,
				Items = category.Items
			};
		}

		private IQueryable<ProductVm> GetCategoryFilter(IQueryable<ProductVm> categoryQuery, CategoryPagedQuery categoryPagedQuery){
			if(categoryPagedQuery.Price.Length != 0){
				foreach(var ind in categoryPagedQuery.Price){
					categoryQuery = categoryQuery.Where(x => x.Price >= ind[0] && x.Price <= ind[1]);
				}
			}
			if(categoryPagedQuery.Rating.Length != 0){
				foreach(var ind in categoryPagedQuery.Rating){
					categoryQuery = categoryQuery.Where(x => x.AvgResult.Equals(ind));
				}
			}
			return categoryQuery;
		}
	}
}
