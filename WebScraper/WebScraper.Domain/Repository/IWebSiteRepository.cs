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
        IQueryable<WebSite> GetAllWebsitesAsQueryable(int userId);
        IQueryable<ScrapedUrl> GetScrapedUrlsByWebsiteAsQueryable(int websiteId);
        Task AddWebSiteUrls(WebSite webSite);
    }
}
