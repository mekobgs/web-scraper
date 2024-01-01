using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Domain.Models;

namespace WebScraper.Application.Interface
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        Task<User> ValidateToken(string token);
    }
}
