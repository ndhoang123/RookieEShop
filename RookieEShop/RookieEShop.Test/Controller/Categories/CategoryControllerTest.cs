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

            var controller = new CategoryController(dbContext);
            var result = await controller.PostCategory(category);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<CategoryVm>(createdAtActionResult.Value);
            Assert.Equal("Test category", returnValue.Name);

        }
    }
}
