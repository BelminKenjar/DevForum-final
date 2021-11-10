using DevForum.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileDetails> ProfileDetails { get; set; }
        public DbSet<ProfileStats> ProfileStats { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<SubTopic> SubTopics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<PostReply> PostReplies { get; set; }
        public DbSet<PostReplyLike> PostReplyLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedAdminUsers(builder);
            SeedProfiles(builder);
        }

        private void SeedProfiles(ModelBuilder builder)
        {
            builder.Entity<Profile>().HasData(
                new Profile { Id = 1, ApplicationUserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575", CreatedAt = DateTime.Now, FirstName = "Amer", LastName = "Hasanbegovic" }
            );
        }

        private void SeedAdminUsers(ModelBuilder builder)
        {
            const string adminId = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string roleId = "5d89570c-41f5-4230-9bac-1f97b925e2f0";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "admin"
            });

            var user = new ApplicationUser()
            {
                Id = adminId,
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var hasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = hasher.HashPassword(user, "Pass@123");
            builder.Entity<ApplicationUser>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
