using RookieEShop.BackEnd.Models;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public interface IRatingRepository
	{
		public Task<IEnumerable<RatingVm>> GetAllRating();

		public Task<RatingVm> GetRatingById(int id);

		public Task<RatingResultVm> GetRatingResult(int productId);

		public Task<bool> CreateRating(Rating rating);

		public Task<bool> DeleteRating(int id);
	}
}
