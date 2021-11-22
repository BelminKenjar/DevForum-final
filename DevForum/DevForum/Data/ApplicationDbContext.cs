using DevForum.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
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
            SeedProfileDetails(builder);
            SeedProfileStats(builder);
            SeedNews(builder);
            SeedTopics(builder);
            SeedSubtopics(builder);
        }

        private void SeedSubtopics(ModelBuilder builder)
        {
            builder.Entity<SubTopic>().HasData(
                new SubTopic 
                { 
                    Id = 1, 
                    CreatedAt = DateTime.Now, 
                    Name = "C++", 
                    Description = "C++ is one of the preferred languages for game development as it supports a variety of coding styles that provides low-level access to the system",
                    ProfileId = 1,
                    TopicId = 1
                },
                new SubTopic
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    Name = "C# Unity",
                    Description = "Game development & design made fun",
                    ProfileId = 1,
                    TopicId = 1
                },
                new SubTopic
                {
                    Id = 3,
                    CreatedAt = DateTime.Now,
                    Name = "NodeJS",
                    Description = "Node.js® is a JavaScript runtime built on Chrome's V8 JavaScript engine.",
                    ProfileId = 1,
                    TopicId = 2
                },
                new SubTopic
                {
                    Id = 4,
                    CreatedAt = DateTime.Now,
                    Name = "Java",
                    Description = "Java — Backend Language #1",
                    ProfileId = 1,
                    TopicId = 2
                },
                new SubTopic
                {
                    Id = 5,
                    CreatedAt = DateTime.Now,
                    Name = "C#",
                    Description = "The C# language is the preferred architecture for backend programming and automation in Windows environments.",
                    ProfileId = 1,
                    TopicId = 2
                },
                new SubTopic
                {
                    Id = 6,
                    CreatedAt = DateTime.Now,
                    Name = "HTML&CSS",
                    Description = "HTML (the Hypertext Markup Language) and CSS (Cascading Style Sheets) are two of the core technologies for building Web pages.",
                    ProfileId = 1,
                    TopicId = 3
                }
                );
        }

        private void SeedTopics(ModelBuilder builder)
        {
            builder.Entity<Topic>().HasData(
                new Topic
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    ProfileId = 1,
                    Title = "Game development",
                    Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    SubTopicCount = 4,
                    Logo = File.ReadAllBytes("Assets/gamedev.png")
                },
                new Topic
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    ProfileId = 1,
                    Title = "Backend development",
                    Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    SubTopicCount = 6,
                    Logo = File.ReadAllBytes("Assets/backend.jpg")
                },
                new Topic
                {
                    Id = 3,
                    CreatedAt = DateTime.Now,
                    ProfileId = 1,
                    Title = "Frontend development",
                    Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    SubTopicCount = 0,
                    Logo = File.ReadAllBytes("Assets/frontend.png")
                }
                );
        }

        private void SeedNews(ModelBuilder builder)
        {
            builder.Entity<News>().HasData(
                new News
                {
                    Id = 1,
                    Title = "Welcome to DevForum!",
                    Content = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                    CreatedAt = DateTime.Now,
                    ProfileId = 1
                },
                new News
                {
                    Id = 2,
                    Title = "Register new account",
                    Content = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.",
                    CreatedAt = DateTime.Now,
                    ProfileId = 1
                }
                );
        }

        private void SeedProfileStats(ModelBuilder builder)
        {
            builder.Entity<ProfileStats>().HasData(
                new ProfileStats { Id = 1, ProfileId = 1, PostsCommented = 3, PostsCreated = 2, Rating = 13 }
                );
        }

        private void SeedProfileDetails(ModelBuilder builder)
        {
            builder.Entity<ProfileDetails>().HasData(
                new ProfileDetails
                {
                    Id = 1,
                    Age = 32,
                    City = "Sanski Most",
                    Country = "BiH",
                    GithubUrl = "https://github.com",
                    FacebookUrl = "https://facebook.com",
                    LinkedinUrl = "https://linkedin.com",
                    ProfileId = 1,
                    TwitterUrl = "https://twitter.com",
                    Website = "https://googla.ba"
                }
                );
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
