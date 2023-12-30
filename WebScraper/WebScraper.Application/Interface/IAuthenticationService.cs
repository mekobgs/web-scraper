using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Application.DTOs;
using WebScraper.Domain.Models;

namespace WebScraper.Application.Interface
{
    public  interface IAuthenticationService
    {
        Task<User> RegisterUser(UserRegistrationDto registrationDto);
        Task<string> LoginUser(UserLoginDto loginDto);
    }
}
