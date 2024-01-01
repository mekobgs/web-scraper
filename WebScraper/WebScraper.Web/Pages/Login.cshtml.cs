using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebScraper.Application.Interface;
using WebScraper.Application.DTOs;

namespace WebScraper.Web.Pages
{
    public class LoginModel : PageModel
    {

        private readonly IAuthenticationService _authenticationService;

        [BindProperty]
        public UserLoginDto LoginDto { get; set; }

        public LoginModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var token = await _authenticationService.LoginUser(LoginDto);
                if (!string.IsNullOrEmpty(token))
                {
                    // Store token in a cookie
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true, 
                        Expires = DateTime.UtcNow.AddDays(7) 
                    };
                    Response.Cookies.Append("JWT", token, cookieOptions);

                    return RedirectToPage("/Websites");
                }
            }
            catch (Exception ex)
            {
                // Handle login failure
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return Page();
        }
    }
}
