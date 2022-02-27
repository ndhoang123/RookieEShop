using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RookieEShop.Shared;

namespace RookieEShop.FrontEnd.Services
{
	public interface IRatingApiClient
	{
		Task<bool> PostRating(RatingCreateRequest ratingCreateRequest);
	}
}
