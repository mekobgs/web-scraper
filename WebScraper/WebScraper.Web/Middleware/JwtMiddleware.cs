using System.Security.Claims;
using WebScraper.Application.Interface;
using WebScraper.Infrastructure.Service;

namespace WebScraper.Web.Middleware
{
    public class JwtMiddleware
    {

        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtService jwtService)
        {
            var token = context.Request.Cookies["JWT"];
            if (token != null)
            {
                try
                {
                    var user = await jwtService.ValidateToken(token);
                    if (user != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.Name),
                            new Claim(ClaimTypes.Email, user.Email),
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, "jwt");
                        context.User = new ClaimsPrincipal(claimsIdentity);
                    }
                }
                catch
                {
                    // Token is invalid
                    context.Response.Redirect("/Login");
                    return;
                }
            }

            await _next(context);
        }
    }
}
