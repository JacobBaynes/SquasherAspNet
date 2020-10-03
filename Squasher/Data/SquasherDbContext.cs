using Microsoft.EntityFrameworkCore;
using Squasher.Models;

namespace Squasher.Data
{
    public class SquasherDbContext : DbContext
    {
        public SquasherDbContext (DbContextOptions<SquasherDbContext> options) : base(options)
        {

        }
        
        public DbSet<BugModel> Bug { get; set; }
        public DbSet<SquasherModel> Squasher { get; set; }
        public DbSet<ProjectModel> Project { get; set; }
    }
}