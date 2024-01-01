using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebScraper.Application.Helpers;
using WebScraper.Application.Interface;
using WebScraper.Domain.Models;

namespace WebScraper.Web.Pages
{
    public class ScrapedUrlsModel : PageModel
    {
        private readonly IWebScrapingService _webScrapingService;
        public int CurrentPageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public int WebsiteId { get; set; }
        public PaginatedList<ScrapedUrl> ScrapedUrls { get; set; }

        public ScrapedUrlsModel(IWebScrapingService webScrapingService)
        {
            _webScrapingService = webScrapingService;
        }

        public async Task<IActionResult> OnGetAsync(int id, int pageIndex = 1)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Login");
            }
            WebsiteId = id;
            CurrentPageIndex = pageIndex;
            ScrapedUrls = await _webScrapingService.GetScrapedUrls(id, CurrentPageIndex, PageSize);

            if (ScrapedUrls == null)
            {
                return RedirectToPage("/Websites");
            }

            return Page();
        }
    }
}
