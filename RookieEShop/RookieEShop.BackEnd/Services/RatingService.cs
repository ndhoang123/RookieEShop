using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Repositories;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Services
{
	public class RatingService : IRatingService
	{
		private readonly IRatingRepository _ratingRepository;

		public RatingService(IRatingRepository ratingRepository)
		{
			_ratingRepository = ratingRepository;
		}

		public async Task<IEnumerable<RatingVm>> ListRating()
		{
			return await _ratingRepository.GetAllRating();
		}

		public async Task<RatingVm> DetailRating(int id)
		{
			return await _ratingRepository.GetRatingById(id);
		}

		public async Task<RatingResultVm> TotalRating(int productId)
		{
			return await _ratingRepository.GetRatingResult(productId);
		}

		public async Task<bool> CreateRating(Rating rating)
		{
			if (await _ratingRepository.CreateRating(rating))
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
			if(await _ratingRepository.DeleteRating(id))
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
