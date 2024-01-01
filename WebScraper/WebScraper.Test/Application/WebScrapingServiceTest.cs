using Moq;
using EntityFrameworkCore.Testing.Moq;
using WebScraper.Application.Helpers;
using WebScraper.Domain.Models;
using WebScraper.Domain.Repository;
using WebScraper.Infrastructure.Service;
using WebScraper.Test.Helpers;

namespace WebScraper.Test.Application
{
    public class WebScrapingServiceTest
    {
        [Fact]
        public async Task GetWebsitesAsync_ReturnsPaginatedWebsites()
        {
            // Arrange
            var mockRepository = new Mock<IWebSiteRepository>();
            var data = GetTestWebsites().AsAsyncQueryable();
            mockRepository.Setup(repo => repo.GetAllWebsitesAsQueryable(1)).Returns(data);

            var service = new WebScrapingService(mockRepository.Object);

            // Act
            var result = await service.GetWebSites(1, 10, 1);

            // Assert
            Assert.IsType<PaginatedList<WebSite>>(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task GetWebsitesAsync_WithNoResults()
        {
            // Arrange
            var mockRepository = new Mock<IWebSiteRepository>();
            var data = GetTestWebsites().AsAsyncQueryable();


            mockRepository.Setup(repo => repo.GetAllWebsitesAsQueryable(2))
                          .Returns(new List<WebSite>().AsAsyncQueryable());

            var service = new WebScrapingService(mockRepository.Object);

            // Act
            var result = await service.GetWebSites(1, 10, 2);

            // Assert
            Assert.IsType<PaginatedList<WebSite>>(result);
            Assert.Empty(result);
        }

        private IQueryable<WebSite> GetTestWebsites()
        {
            var websites = new List<WebSite> {
                new WebSite{
                    Id= 1,
                    Url = "https://www.saiyangrowthletter.com/p/why-you-should-read?utm_source=%252Fbrowse%252Ftechnology&utm_medium=reader2&ref=dailydev",
                    UserId= 1,
                },
                new WebSite{
                    Id= 2,
                    Url = "https://dev.to/opensourcee/2024-is-the-year-of-frontend-for-backend-ffb-6fg?ref=dailydev",
                    UserId= 1,
                },
                new WebSite{
                    Id= 3,
                    Url = "https://www.permit.io/blog/api-authorization-best-practices?ref=dailydev",
                    UserId= 1,
                },
            };

            return websites.AsQueryable();
        }

    }
}
