using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Config
{
    public static class ModelBuilderExtensions
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = UserRoles.ADMIN, NormalizedName = UserRoles.ADMIN.ToUpper() },
                new IdentityRole { Id = "2", Name = UserRoles.USER, NormalizedName = UserRoles.USER.ToUpper() }
        );
        }
    }
}
