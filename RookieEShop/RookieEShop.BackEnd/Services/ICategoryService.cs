using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public interface ICategoryService
	{
		public Task<IEnumerable<Category>> ListAllCategory();

		public Task<Category> ListDetailCategory(int id);

		public Task<bool> CreateCategory(Category category);

		public Task<bool> EditCategory(int id, Category category);

		public Task<bool> DeleteCategory(int id);
	}
}
