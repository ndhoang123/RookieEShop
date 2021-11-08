using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Services;
using RookieEShop.Shared;
using System.Collections.Generic;
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
			var ratingListVm = await _ratingService.ListRating();

			if(ratingListVm == null)
			{
				return StatusCode(404);
			}

			return Ok(ratingListVm);
		}

		[HttpGet("(Id)")]
		[AllowAnonymous]
		public async Task<ActionResult<RatingVm>> GetRating(int id)
		{
			if (id <= 0) return StatusCode(400);

			var ratingVm = await _ratingService.DetailRating(id);

			if (ratingVm == null)
			{
				return NotFound();
			}

			return Ok(ratingVm);
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
				UserId = userId,
				Comment = ratingCreateRequest.Comment
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
