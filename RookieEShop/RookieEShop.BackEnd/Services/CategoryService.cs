using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Repositories;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<IEnumerable<CategoryVm>> ListAllCategory()
		{
			return await _categoryRepository.ReadAllCategory();
		}

		public async Task<CategoryVm> ListDetailCategory(int id)
		{
			return await _categoryRepository.ReadDetailCategory(id);
		}

		public async Task<bool> CreateCategory(Category category)
		{
			if(await _categoryRepository.CreateCategory(category))
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
			if (await _categoryRepository.EditCategory(id, category))
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
			if(await _categoryRepository.DeleteCategory(id))
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
