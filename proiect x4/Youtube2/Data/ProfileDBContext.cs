using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Youtube2.Model;

namespace Youtube2.Data
{
    public class ProfileDBContext : IdentityDbContext
    {
        public ProfileDBContext(DbContextOptions<ProfileDBContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profile { get; set; }
        public DbSet<Videos> Video { get; set; }
        public DbSet<CommentVideo> CommVideo { get; set; }
        public DbSet<CommentChannel> CommCh { get; set; }
        public DbSet<Subscription> Subs { get; set; }
    }
}
