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

        public async Task<List<WebSite>> GetAllWebsitesAsync()
        {
            return await _context.Websites.ToListAsync();
        }

        public async Task<List<ScrapedUrl>> GetScrapedUrlsByWebsiteAsync(int websiteId)
        {
            return await _context.ScrapedUrls.Where(url => url.WebSiteId == websiteId).ToListAsync();
        }
    }
}
