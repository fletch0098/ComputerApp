using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ComputerLibrary.Models;

namespace ComputerDAL
{
    public class ComputerContext : DbContext
    {
        public ComputerContext (DbContextOptions opts)
            : base(opts)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computer>().ToTable("Computer");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Computer> Computers { get; set; }
    }
}