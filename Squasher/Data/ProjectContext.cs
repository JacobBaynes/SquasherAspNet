using Microsoft.EntityFrameworkCore;
using Squasher.Models;

namespace Squasher.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options) : base(options)
        {

        }
        public DbSet<ProjectModel> Project { get; set; }
    }
}