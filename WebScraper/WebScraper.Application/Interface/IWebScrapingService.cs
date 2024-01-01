using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Application.Helpers;
using WebScraper.Domain.Models;

namespace WebScraper.Application.Interface
{
    public interface IWebScrapingService
    {
        Task<List<ScrapedUrl>> ScrapeUrls(string webSiteUrl);
        Task<PaginatedList<ScrapedUrl>> GetScrapedUrls(int webSiteId, int pageIndex, int pageSize);
        Task<PaginatedList<WebSite>> GetWebSites(int pageIndex, int pageSize, int userId);
        Task AddWebsiteWithScrapedUrlsAsync(string url, List<ScrapedUrl> scrapedUrls, int userId);
    }
}
