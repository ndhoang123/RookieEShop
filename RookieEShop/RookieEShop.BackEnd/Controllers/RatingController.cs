using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Services;
using RookieEShop.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize("Bearer")]
	public class RatingController : Controller
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IRatingService _ratingService;

		public RatingController(IHttpContextAccessor httpContextAccessor, 
								IRatingService ratingService)
		{
			_httpContextAccessor = httpContextAccessor;
			_ratingService = ratingService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<IEnumerable<RatingVm>>> GetRating()
		{
			var ratingList = await _ratingService.ListRating();

			var list = ratingList.Select(x => new RatingVm
			{
				Id = x.Id,
				Val = x.Val
			}).ToList();

			return list;
		}

		[HttpGet("(Id)")]
		[AllowAnonymous]
		public async Task<ActionResult<RatingVm>> GetRating(int id)
		{
			if (id <= 0) return StatusCode(400);

			var rating = await _ratingService.DetailRating(id);

			if (rating == null)
			{
				return NotFound();
			}

			var RatingVm = new RatingVm
			{
				Id = rating.Id,
				Val = rating.Val
			};

			return RatingVm;
		}

		[HttpGet("{productId}")]
		[AllowAnonymous]
		public async Task<ActionResult<RatingResultVm>> GetTotalRating(int productId)
		{
			var totalRating = await _ratingService.TotalRating(productId);
			
			if(totalRating == null)
			{
				return StatusCode(404);
			}

			else
			{
				return totalRating;
			}
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult<RatingVm>> CreateRating(RatingCreateRequest ratingCreateRequest)
		{
			var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("sub");

			var rating = new Rating
			{
				Val = ratingCreateRequest.Val,
				ProductId = ratingCreateRequest.ProductId,
				UserId = userId
			};

			if(await _ratingService.CreateRating(rating))
			{
				return CreatedAtAction(nameof(CreateRating), rating);
			}

			else
			{
				return StatusCode(404);
			}
		}

		[HttpDelete("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> DeleteRating(int id)
		{
			if (id <= 0) return StatusCode(400);

			if (await _ratingService.DeleteRating(id))
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
