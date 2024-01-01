using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Application.Helpers;
using WebScraper.Application.Interface;
using WebScraper.Domain.Models;
using WebScraper.Domain.Repository;
using WebScraper.Infrastructure.Repository;

namespace WebScraper.Infrastructure.Service
{
    public class WebScrapingService : IWebScrapingService
    {
        private readonly IWebSiteRepository _webSiteRepository;

        public WebScrapingService(IWebSiteRepository webSiteRepository)
        {
            _webSiteRepository = webSiteRepository;
        }

        public async Task<PaginatedList<ScrapedUrl>> GetScrapedUrls(int webSiteId, int pageIndex, int pageSize)
        {
            var query = _webSiteRepository.GetScrapedUrlsByWebsiteAsQueryable(webSiteId);
            return await PaginatedList<ScrapedUrl>.CreateAsync(query, pageIndex, pageSize);
        }

        public async Task<PaginatedList<WebSite>> GetWebSites(int pageIndex, int pageSize, int userId)
        {
            var query = _webSiteRepository.GetAllWebsitesAsQueryable(userId);

            return await PaginatedList<WebSite>.CreateAsync(query, pageIndex, pageSize);

        }

        public async Task<List<ScrapedUrl>> ScrapeUrls(string webSiteUrl)
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(webSiteUrl);

            var links = doc.DocumentNode.SelectNodes("//a[@href]")
                .Select(node => new ScrapedUrl
                {
                    Url = node.GetAttributeValue("href", string.Empty),
                    Text = node.InnerText.Trim()
                })
                .Distinct()
                .ToList();

            return links;
        }

        public async Task AddWebsiteWithScrapedUrlsAsync(string url, List<ScrapedUrl> scrapedUrls, int userId)
        {
            var WebSiteObj = new WebSite
            {
                UserId= userId,
                Url = url,
                ScrapedUrls = scrapedUrls
            };

            await _webSiteRepository.AddWebSiteUrls(WebSiteObj);
        }
    }
}
