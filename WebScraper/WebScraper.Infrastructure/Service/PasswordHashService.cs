using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Infrastructure.Service
{
    public class PasswordHashService
    {
        public string HashPassword(string password) { 
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hash) {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
