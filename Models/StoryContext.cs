using Microsoft.EntityFrameworkCore;

namespace gamocracy.Models
{
    public class StoryContext : DbContext
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