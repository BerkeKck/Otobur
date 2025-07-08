using Microsoft.AspNetCore.Identity;

namespace Otobur.Models.Models
{
    public class UserWithRolesViewModel
    {
        public IdentityUser User { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}