using Microsoft.EntityFrameworkCore;
using OptimusZQ.DAL.Models;

namespace OptimusZQ.DAL
{
    public class OptimusDbContext : DbContext
    {
        public OptimusDbContext(DbContextOptions<OptimusDbContext> options) : base(options)
        {
        }

        public DbSet<File> Files { get; set; }

        public DbSet<Folder> Folders { get; set; }

        public DbSet<SharedFile> SharedFiles { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(c => c.SharedFiles).WithOne(e => e.User);
            modelBuilder.Entity<User>().HasMany(c => c.Folders).WithOne(e => e.User);
            modelBuilder.Entity<Folder>().HasMany(c => c.Folders).WithOne(e => e.ParentFolder);
            modelBuilder.Entity<Folder>().HasMany(c => c.Files).WithOne(e => e.Folder);  
        }
    }
}
