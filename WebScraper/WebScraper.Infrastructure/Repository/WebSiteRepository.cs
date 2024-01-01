using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Domain.Models;
using WebScraper.Domain.Repository;
using WebScraper.Infrastructure.DataAccess;

namespace WebScraper.Infrastructure.Repository
{
    public class WebSiteRepository : IWebSiteRepository
    {
        private readonly ApplicationDbContext _context;

        public WebSiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<WebSite> GetAllWebsitesAsQueryable(int userId)
        {
            return _context.Websites.Include("ScrapedUrls").Where(x => x.UserId == userId).AsQueryable();
        }

        public IQueryable<ScrapedUrl> GetScrapedUrlsByWebsiteAsQueryable(int websiteId)
        {
            return _context.ScrapedUrls.Where(url => url.WebSiteId == websiteId).AsQueryable();
        }

        public async Task AddWebSiteUrls(WebSite webSite) { 
            await _context.Websites.AddAsync(webSite);
            await _context.SaveChangesAsync();
        }
    }
}
