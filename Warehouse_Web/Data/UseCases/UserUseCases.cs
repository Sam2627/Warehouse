using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace Warehouse_Web.Data.UseCases
{
    public class UserUseCases : IUserUseCases
    {
        private readonly ApplicationUser db;

        private readonly UserManager<ApplicationUser> userManager;

        private AuthenticationStateProvider authenticationStateProvider;

        private ClaimsPrincipal User { get; set; }

        public UserUseCases(ApplicationUser db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        // Using login UserName for userId
        public async Task<string> GetUserName()
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();

            User = authState.User;

            return User.FindFirst("Name").Value;
        }
    }
}
