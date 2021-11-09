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
            SeedSuperUsers(builder);
            SeedProfiles(builder);
        }

        private void SeedProfiles(ModelBuilder builder)
        {
            builder.Entity<Profile>().HasData(
                new Profile { Id = 1, ApplicationUserId = "ID_1", CreatedAt = DateTime.Now, FirstName = "Amer", LastName = "Hasanbegovic" }
            );
        }

        private async void SeedSuperUsers(ModelBuilder builder)
        {
            var rolesStore = new RoleStore<IdentityRole>(this);
            var userStore = new UserStore<ApplicationUser>(this);

            var user = new ApplicationUser
            {
                Id = "ID_1",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            var hash = hasher.HashPassword(user, "Pass@123");
            user.PasswordHash = hash;


            var hasAdminRole = this.Roles.Any(roles => roles.Name == "Admin");
            if (!hasAdminRole)
            {
                await rolesStore.CreateAsync(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
            }

            var hasSuperUser = this.Users.Any(u => u.NormalizedUserName == user.UserName);
            if (!hasSuperUser)
            {
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "Admin");
            }

            builder.Entity<ApplicationUser>().HasData(user);
        }
    }
}
