using Microsoft.AspNetCore.Identity;

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

        public Ordering Order { get; set; }

        public Cart Cart { get; set; }

        [PersonalData]
        public string FullName { get; set; }
    }
}
