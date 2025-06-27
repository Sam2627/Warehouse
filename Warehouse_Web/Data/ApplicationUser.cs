using Microsoft.AspNetCore.Identity;

namespace Warehouse_Web.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
