using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RookieEShop.BackEnd.Models
{
	public class User : IdentityUser
	{
        public User() : base()
        {
        }

        public User(string userName) : base(userName)
        {
        }

        public ICollection<Ordering> Orderings { get; set; }

        [PersonalData]
        public string FullName { get; set; }
    }
}
