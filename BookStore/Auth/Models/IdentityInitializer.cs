using BookStore.Auth.Data;
using BookStore.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Auth.Models
{
    public class IdentityInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_context.Database.EnsureCreated())
            {
                var user = new ApplicationUser()
                {
                    UserName = "admin",
                    Email = "admin@teste.com.br",
                    EmailConfirmed = true
                };
                CreateUser(user, "1VeryStrongPassword!");
            }
        }

        private void CreateUser(ApplicationUser user, string password)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var res = _userManager.CreateAsync(user, password);
            }
        }
    }
}
