using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Warehouse_Web.Data;

namespace Warehouse_Web.Components.Layout
{
    public class LoginPartialModel : PageModel
    {
        private readonly ILogger<LoginPartialModel> _logger;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public string Name { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            var user = _signInManager.IsSignedIn(User) ? await _userManager.GetUserAsync(User) : null;

            Name = user != null ? user.UserName : string.Empty;


        }

        

    }
}
