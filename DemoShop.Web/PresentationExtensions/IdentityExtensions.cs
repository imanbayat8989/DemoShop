using System.Security.Claims;
using System.Security.Principal;

namespace DemoShop.Web.PresentationExtensions
{
    public static class IdentityExtensions
    {
        public static long GetUserId(this ClaimsPrincipal principal)
        {
            if (principal != null)
            {
                var data = principal.Claims.SingleOrDefault(s => s.Type == ClaimTypes.NameIdentifier);
                if (data != null) return Convert.ToInt64(data.Value);
            }
            return default(long);
        }

        public static long GetUserId(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;
            return user.GetUserId();
        }
    }
}
