using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Domain.Models;
using WebScraper.Domain.Repository;
using WebScraper.Infrastructure.DataAccess;
using WebScraper.Infrastructure.Repository;

namespace WebScraper.Test.Infrastructure
{
    public class WebSiteRepositoryTest
    {
        [Fact]
        public async Task AddWebsiteAsync_SavesToDatabase()
        {
            // Use InMemory database for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Arrange
            using var context = new ApplicationDbContext(options);
            var repository = new WebSiteRepository(context);

            // Act
            await repository.AddWebSiteUrls(new WebSite { Url = "https://www.permit.io/blog/api-authorization-best-practices?ref=dailydev", UserId = 1 });

            // Assert
            Assert.Equal(1, context.Websites.Count());
        }
    }
}
