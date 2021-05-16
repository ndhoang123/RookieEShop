using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public interface IRatingService
	{
		public Task<IEnumerable<Rating>> ListRating();

		public Task<Rating> DetailRating(int id);

		public Task<RatingResultVm> TotalRating(int productId);

		public Task<bool> CreateRating(Rating rating);

		public Task<bool> DeleteRating(int id);
	}
}
