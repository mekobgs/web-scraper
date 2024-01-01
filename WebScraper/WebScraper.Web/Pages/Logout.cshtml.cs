using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebScraper.Web.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            // Remove the JWT cookie
            Response.Cookies.Delete("JWT");

            // Optionally, redirect to the login page or home page after logout
            return RedirectToPage("/Index");
        }
    }
}
