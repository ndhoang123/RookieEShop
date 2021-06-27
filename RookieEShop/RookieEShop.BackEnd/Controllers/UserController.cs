using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : Controller
	{
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
 
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<User>>> GetCustomers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
