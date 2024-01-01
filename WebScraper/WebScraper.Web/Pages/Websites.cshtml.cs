using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebScraper.Application.Helpers;
using WebScraper.Application.Interface;
using WebScraper.Domain.Models;

namespace WebScraper.Web.Pages
{
    public class WebsitesModel : PageModel
    {
        private readonly IWebScrapingService _webScrapingService;
        public int CurrentPageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10; 

        [BindProperty]
        public string WebsiteUrl { get; set; }

        public PaginatedList<WebSite> Websites { get; set; }

        public WebsitesModel(IWebScrapingService webScrapingService)
        {
            _webScrapingService = webScrapingService;
        }

        public async Task OnGetAsync(int pageIndex = 1)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Login");
            }
            CurrentPageIndex = pageIndex;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                int userId = int.Parse(userIdClaim.Value);
                Websites = await _webScrapingService.GetWebSites(CurrentPageIndex, PageSize, userId);
            }
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(WebsiteUrl))
            {
                var scrapedUrls = await _webScrapingService.ScrapeUrls(WebsiteUrl);
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null)
                {
                    int userId = int.Parse(userIdClaim.Value);
                    await _webScrapingService.AddWebsiteWithScrapedUrlsAsync(WebsiteUrl, scrapedUrls, userId);
                }              
            }

            return RedirectToPage();
        }
    }
}
