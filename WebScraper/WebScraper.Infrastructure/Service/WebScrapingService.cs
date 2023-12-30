using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Application.Interface;
using WebScraper.Domain.Models;
using WebScraper.Domain.Repository;

namespace WebScraper.Infrastructure.Service
{
    public class WebScrapingService : IWebScrapingService
    {
        private readonly IWebSiteRepository _webSiteRepository;

        public WebScrapingService(IWebSiteRepository webSiteRepository)
        {
            _webSiteRepository = webSiteRepository;
        }

        public Task<List<ScrapedUrl>> GetScrapedUrls(int webSiteId)
        {
            return _webSiteRepository.GetScrapedUrlsByWebsiteAsync(webSiteId);
        }

        public Task<List<WebSite>> GetWebSites()
        {
            return _webSiteRepository.GetAllWebsitesAsync();
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
    }
}
