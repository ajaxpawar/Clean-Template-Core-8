using Microsoft.AspNetCore.Identity;

namespace Domain.User
{
    public class ApplicationUser : IdentityUser
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireTime { get; set; }
    }
}
