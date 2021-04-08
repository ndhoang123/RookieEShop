using Microsoft.AspNetCore.Mvc;
using RookieEShop.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.FrontEnd.ViewComponents
{
	public class CategoryMenuViewComponent : ViewComponent
	{
        private readonly ICategoryApiClient _categoryApiClient;

        public CategoryMenuViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryApiClient.GetCategories();

            return View(categories);
        }
    }
}
