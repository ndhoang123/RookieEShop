using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RookieEShop.BackEnd.Services;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize("Bearer")]
	public class CheckoutController : Controller
	{
		private readonly ICheckoutService _ICheckoutService;

		public CheckoutController(ICheckoutService ICheckoutService)
		{
			_ICheckoutService = ICheckoutService;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<ActionResult> GetShipping(string id)
		{
			var listOrder = await _ICheckoutService.GetShipping(id);

			return Ok(listOrder);
		}
	}
}
