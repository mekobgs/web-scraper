using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Domain.Models;

namespace WebScraper.Domain.Repository
{
    public interface IWebSiteRepository
    {
        Task<List<WebSite>> GetAllWebsitesAsync();
        Task<List<ScrapedUrl>> GetScrapedUrlsByWebsiteAsync(int websiteId);
    }
}
