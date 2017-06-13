using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evdokimov.Models
{
    public class AppDbContextSeedData
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AppDbContextSeedData(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if (await _userManager.FindByEmailAsync("sam.hastings@theworld.com") == null)
            {

                var user = new IdentityUser()
                {
                    UserName = "VistaS",
                    Email = "evdokimov@sibnet.ru"
                };

                await _userManager.CreateAsync(user, "");
                await _context.SaveChangesAsync();

            }
        }
    }
}
