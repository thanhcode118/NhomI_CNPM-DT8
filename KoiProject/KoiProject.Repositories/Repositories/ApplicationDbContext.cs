using KoiProject.Repositories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Services.Service
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {
        
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var judge = new IdentityRole("judge");
            judge.NormalizedName = "judge";

            var contestant = new IdentityRole("contestant");
            judge.NormalizedName = "contestant";

            builder.Entity<IdentityRole>().HasData(admin,judge,contestant);
        }
    }
}
