using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Application.DTOs;
using WebScraper.Application.Interface;
using WebScraper.Domain.Models;
using WebScraper.Domain.Repository;

namespace WebScraper.Infrastructure.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository; // Assuming you have a user repository
        private readonly PasswordHashService _passwordHashService;
        private readonly JwtService _jwtService;

        public AuthenticationService(
            IUserRepository userRepository,
            PasswordHashService passwordHashService,
            JwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
            _jwtService = jwtService;
        }

        public async Task<User> RegisterUser(UserRegistrationDto registrationDto)
        {
            // Check if user already exists
            if (await _userRepository.GetUserByEmailAsync(registrationDto.Email) != null)
            {
                throw new Exception("User already exists.");
            }

            // Hash the password
            var hashedPassword = _passwordHashService.HashPassword(registrationDto.Password);

            var user = new User
            {
                Email = registrationDto.Email,
                PasswordHash = hashedPassword
            };

            await _userRepository.AddUserAsync(user);

            return user;
        }

        public async Task<string> LoginUser(UserLoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            // Validate user and password
            if (user == null || !_passwordHashService.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                throw new Exception("Invalid credentials.");
            }

            // Generate JWT token
            return _jwtService.GenerateToken(user);
        }
    }
}
