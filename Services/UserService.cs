using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chirper.Data;
using Chirper.Models;
using Microsoft.AspNetCore.Identity;

namespace Chirper.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserService(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> IsUsernameTakenAsync(string username)
        {
            return await _userManager.FindByNameAsync(username) != null;
        }

        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task<IdentityResult> CreateUserAsync(string username, string email, string password)
        {
            var user = new User
            {
                UserName = username,
                Email = email
            };

            return await _userManager.CreateAsync(user, password);
        }

        public async Task<User?> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }
    }
}