using Microsoft.EntityFrameworkCore;
using Squasher.Models;

namespace Squasher.Data
{
    public class SquasherDbContext : DbContext
    {
        public SquasherDbContext(DbContextOptions<SquasherDbContext> options) : base(options)
        {
        }

        public DbSet<BugModel> Bugs { get; set; }
        public DbSet<SquasherModel> Squashers { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BugModel>().ToTable("Bug");
            modelBuilder.Entity<SquasherModel>().ToTable("Squasher");
            modelBuilder.Entity<ProjectModel>().ToTable("Project");

            modelBuilder.Entity<BugSquasherModel>()
                .HasKey(b => new { b.BugId, b.SquasherId });

            modelBuilder.Entity<BugSquasherModel>()
                .HasOne(bs => bs.Bug)
                .WithMany(b => b.BugSquashers)
                .HasForeignKey(bs => bs.BugId);

            modelBuilder.Entity<BugSquasherModel>()
                .HasOne(bs => bs.Squasher)
                .WithMany(s => s.BugSquashers)
                .HasForeignKey(bs => bs.SquasherId);

            modelBuilder.Entity<ProjectSquasherModel>()
                .HasKey(p => new { p.ProjectId, p.SquasherId });

            modelBuilder.Entity<ProjectSquasherModel>()
                .HasOne(ps => ps.Project)
                .WithMany(p => p.ProjectSquashers)
                .HasForeignKey(ps => ps.ProjectId);

            modelBuilder.Entity<ProjectSquasherModel>()
                .HasOne(ps => ps.Squasher)
                .WithMany(s => s.ProjectSquashers)
                .HasForeignKey(ps => ps.SquasherId);
        }
    }
}