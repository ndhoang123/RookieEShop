using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RookieEShop.BackEnd.IdentityServer;
using RookieEShop.BackEnd.Models;

namespace RookieEShop.BackEnd.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IConfiguration _configuration;

        public LogoutModel(SignInManager<User> signInManager, ILogger<LogoutModel> logger, 
            IIdentityServerInteractionService iteraction, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _logger = logger;
            _interaction = iteraction;
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            return await this.OnPost(returnUrl);
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            var logoutId = this.Request.Query["logoutId"].ToString();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }

            else if (!string.IsNullOrEmpty(logoutId))
			{
                var logoutContext = await this._interaction.GetLogoutContextAsync(logoutId);
                returnUrl = logoutContext.PostLogoutRedirectUri;

				if (!string.IsNullOrEmpty(returnUrl))
				{
                    return this.Redirect(returnUrl);
				}

				else
				{
                    var clientIdTemp = logoutContext.ClientIds.ToArray()[0];
                    var referrer = IdentityServerConfig.Clients(_configuration).Where(item => item.ClientId == clientIdTemp).First();
                    string urlCallBack = referrer.PostLogoutRedirectUris.First();
                    if (referrer != null) return this.Redirect(urlCallBack);
                    return Page();
                }
			}
            else
            {
                return RedirectToPage();
            }
        }
    }
}
