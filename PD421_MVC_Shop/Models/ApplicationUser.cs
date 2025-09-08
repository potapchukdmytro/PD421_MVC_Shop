using Microsoft.AspNetCore.Identity;

namespace PD421_MVC_Shop.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public override string Id { get; set; } = Guid.NewGuid().ToString();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
