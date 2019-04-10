using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OptimusZQ.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
