using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> ReadAllCategory();

		Task<Category> ReadDetailCategory(int id);

		Task<bool> CreateCategory(Category category);

		Task<bool> EditCategory(int id, Category category);

		Task<bool> DeleteCategory(int id);
	}
}
