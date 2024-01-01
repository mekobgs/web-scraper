using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebScraper.Application.Interface;
using WebScraper.Application.DTOs;

namespace WebScraper.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IAuthenticationService _authenticationService;

        [BindProperty]
        public UserRegistrationDto RegistrationDto { get; set; }

        public RegisterModel(IAuthenticationService authenticationService)
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
                var user = await _authenticationService.RegisterUser(RegistrationDto);
                return RedirectToPage("/Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "User registration failed.");
            }

            return Page();
        }
    }

}