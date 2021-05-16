using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public class RatingRepository : IRatingRepository
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public RatingRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
		{
			_dbContext = dbContext;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IEnumerable<Rating>> GetAllRating()
		{
			return await _dbContext.Ratings.ToListAsync();
		}

		public async Task<Rating> GetRatingById(int id)
		{
			return await _dbContext.Ratings.FindAsync(id);
		}

		public async Task<RatingResultVm> GetRatingResult(int productId)
		{
			var listRating = await _dbContext.Ratings.Where(item => item.ProductId == productId).Include(item => item.User)
				.Select(x => new RatingVm
				{
					Id = x.Id,
					Val = x.Val,
					UserName = x.User.UserName
				})
				.ToListAsync();

			var avgRating = listRating.Sum(item => item.Val) / listRating.Count;

			var resultList = new RatingResultVm
			{
				AvgResult = avgRating,
				CountResult = listRating.Count,
				ListRating = listRating
			};


			return resultList;
		}

		public async Task<bool> CreateRating(Rating rating)
		{

			await _dbContext.Ratings.AddAsync(rating);

			if(await _dbContext.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public async Task<bool> DeleteRating(int id)
		{
			var rating = await _dbContext.Ratings.FindAsync(id);
			if (rating == null)
			{
				return false;
			}

			_dbContext.Ratings.Remove(rating);

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
