using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<IEnumerable<CategoryVm>> ReadAllCategory()
		{
			var listCategory = await _dbContext.Categories.ToListAsync();

			var listCategoryVm = listCategory.Select(x => new CategoryVm
			{
				Id = x.Id,
				Name = x.Name
			}).ToList();

			return listCategoryVm;
		}

		public async Task<CategoryVm> ReadDetailCategory(int id)
		{
			var detailCategory = await _dbContext.Categories.FindAsync(id);
			var categoryVm = new CategoryVm
			{
				Id = detailCategory.Id,
				Name = detailCategory.Name
			};

			return categoryVm;
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
