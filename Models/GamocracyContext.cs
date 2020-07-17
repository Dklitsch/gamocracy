using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gamocracy.Models
{
    public class GamocracyContext : IdentityDbContext<IdentityUser>
    {
        public GamocracyContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}