using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace gamocracy.Models
{
    public class GamocracyContext : IdentityDbContext<IdentityUser>
    {

        public GamocracyContext()
        {
        }
        public GamocracyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydb.db;");
        }

        public DbSet<Story> Stories { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}