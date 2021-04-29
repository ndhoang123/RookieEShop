using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
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
		private readonly ApplicationDbContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public RatingController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<IEnumerable<RatingVm>>> GetRating()
		{
			return await _context.Ratings
				.Select(x => new RatingVm
				{
					Id = x.Id,
					Val = x.Val
				})
				.ToListAsync();
		}

		[HttpGet("(Id)")]
		[AllowAnonymous]
		public async Task<ActionResult<RatingVm>> GetRating(int id)
		{
			var rating = await _context.Ratings.FindAsync(id);

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
			var listRating = await _context.Ratings.Where(item => item.ProductId == productId).Include(item => item.User)
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

		[HttpPost]
		public async Task<ActionResult<RatingVm>> PostRating(RatingCreateRequest ratingCreateRequest)
		{
			var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("sub");
			var rating = new Rating
			{
				Val = ratingCreateRequest.Val,
				ProductId = ratingCreateRequest.ProductId,
				UserId = userId
			};

			await _context.Ratings.AddAsync(rating);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetRating", new { id = rating.Id }, null);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRating(int id)
		{
			var rating = await _context.Ratings.FindAsync(id);
			if (rating == null)
			{
				return NotFound();
			}

			_context.Ratings.Remove(rating);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
