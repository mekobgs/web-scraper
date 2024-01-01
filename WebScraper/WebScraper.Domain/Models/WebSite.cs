using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Domain.Models
{
    public class WebSite
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<ScrapedUrl> ScrapedUrls { get; set; }
    }
}
