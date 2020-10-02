using Microsoft.EntityFrameworkCore;
using Squasher.Models;

namespace Squasher.Data
{
    public class SquasherContext : DbContext
    {
        public SquasherContext (DbContextOptions<SquasherContext> options) : base(options)
        {

        }
        public DbSet<SquasherModel> Squasher { get; set; }
    }
}