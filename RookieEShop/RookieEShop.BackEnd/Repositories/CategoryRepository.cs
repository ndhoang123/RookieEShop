using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public CategoryRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Category>> ReadAllCategory()
		{
			return await _dbContext.Categories.ToListAsync();
		}

		public async Task<Category> ReadDetailCategory(int id)
		{
			return await _dbContext.Categories.FindAsync(id);
		}

		public async Task<bool> CreateCategory(Category category)
		{
			_dbContext.Categories.Add(category);

			if(await _dbContext.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public async Task<bool> EditCategory(int id, Category category)
		{
			var oldCategory = await _dbContext.Categories.FindAsync(id);

			if(oldCategory == null)
			{
				return false;
			}

			oldCategory.Name = category.Name;

			if (await _dbContext.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public async Task<bool> DeleteCategory(int id)
		{
			var oldCategory = await _dbContext.Categories.FindAsync(id);

			if(oldCategory == null)
			{
				return false;
			}

			_dbContext.Categories.Remove(oldCategory);
			
			if(await _dbContext.SaveChangesAsync() > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
