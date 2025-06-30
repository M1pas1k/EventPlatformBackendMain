using System.Security.Claims;

namespace WebApplication.API.Extensions
{
    public static class ClaimPrincipialExtensions
    {
        public static Guid Id(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}