using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Services;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CategoryController : ControllerBase
	{
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CategoryVm>>> GetAllCategory()
        {
            var listCategory = await _categoryService.ListAllCategory();
            var listCategoryVm = listCategory.Select(x => new CategoryVm
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return listCategoryVm;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryVm>> GetDetailCategory(int id)
        {
            if (id <= 0) return StatusCode(400);

            var detailCategory = await _categoryService.ListDetailCategory(id);

            if(detailCategory == null)
			{
                return NotFound();
			}

            var categoryVm = new CategoryVm
            {
                Id = detailCategory.Id,
                Name = detailCategory.Name
            };

            return categoryVm;
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutCategory(int id, CategoryCreateRequest categoryCreateRequest)
        {
            if (id <= 0) return StatusCode(400);

            var putCategory = new Category
            {
                Name = categoryCreateRequest.Name

            };

            var isSuccessfulEdit = await _categoryService.EditCategory(id, putCategory);

			if (isSuccessfulEdit)
			{
                return StatusCode(204);
			}

			else
			{
                return StatusCode(404);
			}
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryVm>> PostCategory([FromForm]CategoryCreateRequest categoryCreateRequest)
        {
            var category = new Category
            {
                Name = categoryCreateRequest.Name
            };

            var isSuccessCreate = await _categoryService.CreateCategory(category);

			if (isSuccessCreate)
			{
                return CreatedAtAction("GetCategory", new { id = category.Id }, new CategoryVm { Id = category.Id, Name = category.Name });
            }

			else
			{
                return StatusCode(404);
			}
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id <= 0) return StatusCode(400);

            var isSuccessDelete = await _categoryService.DeleteCategory(id);
			if (isSuccessDelete)
			{
                return StatusCode(204);
			}

			else
			{
                return StatusCode(404);
			}
        }
    }
}
