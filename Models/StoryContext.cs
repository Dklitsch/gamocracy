using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gamocracy.Models
{
    public class StoryContext : IdentityDbContext<IdentityUser>
    {
        private static bool _created = false;

        public StoryContext(DbContextOptions options) : base(options)
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        public DbSet<Story> Stories { get; set; }

        public DbSet<Scene> Scenes { get; set; }

        public DbSet<Option> Options { get; set; }
    }
}