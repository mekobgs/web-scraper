using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Domain.Models
{
    public class ScrapedUrl
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
        public int WebSiteId { get; set; }
        public WebSite WebSite { get; set; }
    }
}
