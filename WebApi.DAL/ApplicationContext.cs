using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.DAL.ConfigureDatabase;
using WebApi.DAL.Entities;

namespace WebApi.DAL
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FriendList> Friends { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appSettings.json");

            IConfigurationRoot config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfigureDatabase();

            base.OnModelCreating(modelBuilder);
        }
    }
}
