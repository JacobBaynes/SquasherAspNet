using Microsoft.EntityFrameworkCore;
using Squasher.Models;

namespace Squasher.Data
{
    public class BugContext : DbContext
    {
        public BugContext (DbContextOptions<BugContext> options) : base(options)
        {

        }
        public DbSet<BugModel> Bug { get; set; }
    }
}