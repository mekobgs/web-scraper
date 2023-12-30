using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Domain.Models;

namespace WebScraper.Application.Interface
{
    public interface IWebScrapingService
    {
        Task<List<ScrapedUrl>> ScrapeUrls(string webSiteUrl);
        Task<List<ScrapedUrl>> GetScrapedUrls(int webSiteId);
        Task<List<WebSite>> GetWebSites();
    }
}
