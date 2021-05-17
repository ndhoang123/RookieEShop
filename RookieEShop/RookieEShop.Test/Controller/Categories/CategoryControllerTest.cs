using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RookieEShop.BackEnd.Controllers;
using RookieEShop.Shared;
using System.Linq;
using RookieEShop.BackEnd.Models;
using System.Collections.Generic;
using RookieEShop.BackEnd.Repositories;
using RookieEShop.BackEnd.Services;

namespace RookieEShop.BackEnd.Tests.Controller.Categories
{
	public class CategoryControllerTest : IClassFixture<SqliteInMemoryFixture>
	{
        private readonly SqliteInMemoryFixture _fixture;

        public CategoryControllerTest(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task PostCategory_Success()
		{
            var dbContext = _fixture.Context;
            var category = new CategoryCreateRequest { Name = "Test category" };

            var categoryRepository = new CategoryRepository(dbContext);
            var categoryService = new CategoryService(categoryRepository);
            var controller = new CategoryController(categoryService);

            var result = await controller.PostCategory(category);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<CategoryVm>(createdAtActionResult.Value);
            Assert.Equal("Test category", returnValue.Name);

        }

        [Fact]
        public async Task GetCategory_Success()
		{
            //Arrange
            var dbContext = _fixture.Context;
            dbContext.Categories.Add(new Category { Name = "Test category" });
            await dbContext.SaveChangesAsync();

            var categoryRepository = new CategoryRepository(dbContext);
            var categoryService = new CategoryService(categoryRepository);
            var controller = new CategoryController(categoryService);
            // Act
            var result = await controller.GetAllCategory();
            // Assert
            var actionResultType = Assert.IsType<ActionResult<IEnumerable<CategoryVm>>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.NotEmpty(actionResult.Value as IEnumerable<CategoryVm>);
        }

        [Fact]
        public async Task PutCategory_Success()
		{
            //Arrange
            var dbContext = _fixture.Context;
            dbContext.Categories.Add(new Category { Name = "Test category" });
            await dbContext.SaveChangesAsync();

            var oldCategory = await dbContext.Categories.OrderByDescending(x => x.Id).FirstAsync();
            var category = new CategoryCreateRequest { Name = "Test put category" };

            var categoryRepository = new CategoryRepository(dbContext);
            var categoryService = new CategoryService(categoryRepository);
            var controller = new CategoryController(categoryService);

            //Act
            var result = await controller.PutCategory(oldCategory.Id, category);

            //Assert
            var returnValue = await dbContext.Categories.OrderByDescending(x => x.Id).FirstAsync();
            Assert.Equal("Test put category", returnValue.Name);
        }

        [Fact]
        public async Task DeleteCategory_Success() 
        {
            var dbContext = _fixture.Context;
            dbContext.Categories.Add(new Category { Name = "Test category" });
            await dbContext.SaveChangesAsync();

            var oldCategory = await dbContext.Categories.OrderByDescending(x => x.Id).FirstAsync();

            var categoryRepository = new CategoryRepository(dbContext);
            var categoryService = new CategoryService(categoryRepository);
            var controller = new CategoryController(categoryService);

            var result = await controller.DeleteCategory(oldCategory.Id);

            var returnValue = await dbContext.Categories.ToListAsync();
            Assert.Empty(returnValue);
        }
    }
}
